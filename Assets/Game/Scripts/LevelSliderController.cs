using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelSliderController : MonoBehaviour, IEndDragHandler, IBeginDragHandler
{
    [Header("Referências da UI")]
    public ScrollRect scrollRect;
    public RectTransform contentPanel;
    public GameObject cardFasePrefab;
    public Button btnAnterior;
    public Button btnProximo;

    [Header("Lista de Fases (Coloque a Fase 0 no índice 0)")]
    public List<FaseDataSO> listaFases;

    [Header("Suavização do Movimento")]
    public float velocidadeSnap = 10f;

    private List<RectTransform> cardsInstanciados = new List<RectTransform>();
    private int indiceAtual = 0;
    private bool estaArrastando = false;
    private float[] posicoesNormalizadas;

    void Start()
    {
        GerarCards();
        ConfigurarBotoes();
        AtualizarEstadoBotoes();
    }

    void GerarCards()
    {
        foreach (Transform child in contentPanel)
            Destroy(child.gameObject);

        cardsInstanciados.Clear();

        for (int i = 0; i < listaFases.Count; i++)
        {
            FaseDataSO dados = listaFases[i];
            GameObject novoCard = Instantiate(cardFasePrefab, contentPanel);
            cardsInstanciados.Add(novoCard.GetComponent<RectTransform>());

            // Aplica a cor de destaque definida no ScriptableObject
            Image imgFundo = novoCard.GetComponent<Image>();
            if (imgFundo != null) imgFundo.color = dados.corDestaqueSetor;

            // Preenche o número grande (ou "Tutorial" na Fase 0) sem textos longos
            TMP_Text txtNumero = novoCard.transform.Find("TextoNumeroFase")?.GetComponent<TMP_Text>();
            if (txtNumero != null)
            {
                txtNumero.text = dados.ehTutorial ? "0\n(Treino)" : dados.numeroFase.ToString();
            }

            // Mostra indicadores curtos de obstáculos apenas se estiverem ativos
            TMP_Text txtObstaculos = novoCard.transform.Find("TextoIconesObstaculos")?.GetComponent<TMP_Text>();
            if (txtObstaculos != null)
            {
                string info = "";
                if (dados.temFumacaNasPlacas) info += "Fumaça ";
                if (dados.temCorredoresBloqueados) info += "Bloqueio";
                txtObstaculos.text = info;
            }

            int indexCaptura = i;
            Button btnCard = novoCard.GetComponent<Button>();
            btnCard.onClick.AddListener(() => AoClicarNoCard(indexCaptura));
        }

        Canvas.ForceUpdateCanvases();
        CalcularPosicoes();
    }

    void CalcularPosicoes()
    {
        posicoesNormalizadas = new float[listaFases.Count];
        if (listaFases.Count <= 1)
        {
            if (listaFases.Count == 1) posicoesNormalizadas[0] = 0f;
            return;
        }

        float distanciaEntreItens = 1f / (listaFases.Count - 1f);
        for (int i = 0; i < listaFases.Count; i++)
        {
            posicoesNormalizadas[i] = distanciaEntreItens * i;
        }
    }

    void Update()
    {
        if (!estaArrastando && posicoesNormalizadas != null && posicoesNormalizadas.Length > 0)
        {
            float alvo = posicoesNormalizadas[indiceAtual];
            scrollRect.horizontalNormalizedPosition = Mathf.Lerp(
                scrollRect.horizontalNormalizedPosition,
                alvo,
                Time.deltaTime * velocidadeSnap
            );

            // Destaque suave na escala do cartão centralizado
            for (int i = 0; i < cardsInstanciados.Count; i++)
            {
                float escalaAlvo = (i == indiceAtual) ? 1.1f : 0.9f;
                cardsInstanciados[i].localScale = Vector3.Lerp(
                    cardsInstanciados[i].localScale,
                    Vector3.one * escalaAlvo,
                    Time.deltaTime * velocidadeSnap
                );
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData) => estaArrastando = true;

    public void OnEndDrag(PointerEventData eventData)
    {
        estaArrastando = false;
        EncontrarFaseMaisProxima();
    }

    void EncontrarFaseMaisProxima()
    {
        float posAtual = scrollRect.horizontalNormalizedPosition;
        float menorDistancia = Mathf.Infinity;
        int novoIndice = indiceAtual;

        for (int i = 0; i < posicoesNormalizadas.Length; i++)
        {
            float dist = Mathf.Abs(posAtual - posicoesNormalizadas[i]);
            if (dist < menorDistancia)
            {
                menorDistancia = dist;
                novoIndice = i;
            }
        }

        SelecionarIndice(novoIndice);
    }

    public void ProximaFase()
    {
        if (indiceAtual < listaFases.Count - 1)
            SelecionarIndice(indiceAtual + 1);
    }

    public void FaseAnterior()
    {
        if (indiceAtual > 0)
            SelecionarIndice(indiceAtual - 1);
    }

    void SelecionarIndice(int novoIndice)
    {
        indiceAtual = novoIndice;
        AtualizarEstadoBotoes();
    }

    void AoClicarNoCard(int indiceClicado)
    {
        // Se clicou num card lateral, centraliza primeiro; se já está no centro, inicia o jogo
        if (indiceClicado != indiceAtual)
        {
            SelecionarIndice(indiceClicado);
        }
        else
        {
            IniciarFaseEscolhida(listaFases[indiceAtual]);
        }
    }

    void ConfigurarBotoes()
    {
        if (btnAnterior != null) btnAnterior.onClick.AddListener(FaseAnterior);
        if (btnProximo != null) btnProximo.onClick.AddListener(ProximaFase);
    }

    void AtualizarEstadoBotoes()
    {
        if (btnAnterior != null) btnAnterior.interactable = (indiceAtual > 0);
        if (btnProximo != null) btnProximo.interactable = (indiceAtual < listaFases.Count - 1);
    }

    void IniciarFaseEscolhida(FaseDataSO faseSelecionada)
    {
        // Salva a ficha da fase no GameManager persistente antes de abrir a cena Gameplay
        if (GameManager.Instance != null)
        {
            GameManager.Instance.SelecionarFase(faseSelecionada);
        }

        SceneManager.LoadScene(faseSelecionada.nomeCenaGameplay);
    }
}