using UnityEngine;
using UnityEngine.SceneManagement;

public class CicloEntregaManager : MonoBehaviour
{
    [Header("Visual da Caixa no Robô")]
    public GameObject pacoteCarregadoVisual;
    public Material matAzul;
    public Material matVerde;
    public Material matAmarelo;

    [Header("Regras da Fase")]
    public int entregasNecessarias = 3;
    public int entregasConcluidas = 0;

    [HideInInspector] public bool estaCarregandoPacote = false;
    private CorSetor corAtualCarregada;
    private PacoteColetavel ultimoPacoteColetado;

    void Start()
    {
        // Lê o total de entregas da ficha da fase (FaseDataSO) se vier do Menu
        if (GameManager.Instance != null && GameManager.Instance.faseAtualSelecionada != null)
        {
            entregasNecessarias = GameManager.Instance.faseAtualSelecionada.entregasParaVencer;
        }
    }

    public void ColetarPacote(PacoteColetavel pacote)
    {
        estaCarregandoPacote = true;
        corAtualCarregada = pacote.corDoPacote;
        ultimoPacoteColetado = pacote;

        // Esconde o pacote do chão e mostra na frente do robô com a cor certa
        pacote.gameObject.SetActive(false);
        if (pacoteCarregadoVisual != null)
        {
            pacoteCarregadoVisual.SetActive(true);
            MeshRenderer render = pacoteCarregadoVisual.GetComponent<MeshRenderer>();
            if (render != null) render.material = ObterMaterialPorCor(corAtualCarregada);
        }

        Debug.Log($"Pacote {corAtualCarregada} coletado! Siga as placas dessa cor.");
    }

    public void TentarEntregarNoSetor(CorSetor corDoSetor)
    {
        if (corDoSetor == corAtualCarregada)
        {
            // Entrega correta!
            estaCarregandoPacote = false;
            entregasConcluidas++;

            if (pacoteCarregadoVisual != null)
                pacoteCarregadoVisual.SetActive(false);

            Debug.Log($"Entrega concluída! ({entregasConcluidas}/{entregasNecessarias})");

            // Verifica condição de vitória (completar max_deliveries)
            if (entregasConcluidas >= entregasNecessarias)
            {
                Debug.Log("Fase Concluída com Sucesso!");
                SceneManager.LoadScene("Results");
            }
            else if (ultimoPacoteColetado != null)
            {
                // Alterna a cor do próximo pacote e o faz reaparecer para a próxima entrega
                ultimoPacoteColetado.corDoPacote = (corAtualCarregada == CorSetor.Azul) ? CorSetor.Verde : CorSetor.Azul;
                MeshRenderer renderChao = ultimoPacoteColetado.GetComponent<MeshRenderer>();
                if (renderChao != null) renderChao.material = ObterMaterialPorCor(ultimoPacoteColetado.corDoPacote);
                ultimoPacoteColetado.gameObject.SetActive(true);
            }
        }
        else
        {
            // Setor incorreto: mantém a caixa com o robô, sem punição nem Game Over
            Debug.Log($"Setor {corDoSetor} não corresponde ao pacote {corAtualCarregada}. Consulte as placas!");
        }
    }

    private Material ObterMaterialPorCor(CorSetor cor)
    {
        if (cor == CorSetor.Verde) return matVerde;
        if (cor == CorSetor.Amarelo) return matAmarelo;
        return matAzul;
    }
}