using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RoboController : MonoBehaviour
{
    [Header("Configurações de Movimento")]
    public float velocidadeBase = 3.5f;
    public float velocidadeGiroBase = 110f;

    [Header("Botões Touch da Tela (Opcional no PC, obrigatório para Tablet)")]
    public BotaoTouchDirecional btnFrente;
    public BotaoTouchDirecional btnTras;
    public BotaoTouchDirecional btnEsquerda;
    public BotaoTouchDirecional btnDireita;

    private Rigidbody rb;
    private float multiplicadorSensibilidade = 1f;
    private Vector3 posicaoSeguraAtual;
    private Quaternion rotacaoSeguraAtual;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        posicaoSeguraAtual = transform.position;
        rotacaoSeguraAtual = transform.rotation;

        // 1. Lê a velocidade da fase selecionada no Passo 3 (se existir)
        if (GameManager.Instance != null && GameManager.Instance.faseAtualSelecionada != null)
        {
            velocidadeBase = GameManager.Instance.faseAtualSelecionada.velocidadeRobo;
        }

        // 2. Lê a sensibilidade configurada no Passo 2 (se existir)
        if (SettingsManager.Instance != null)
        {
            multiplicadorSensibilidade = SettingsManager.Instance.ObterSensibilidadeAtiva();
        }
    }

    void FixedUpdate()
    {
        float avanco = 0f;
        float giro = 0f;

        // Leitura do Teclado (W/S/A/D e Setas)
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) avanco += 1f;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) avanco -= 1f;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) giro -= 1f;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) giro += 1f;

        // Leitura dos Botões Virtuais na Tela (Touchscreen)
        if (btnFrente != null && btnFrente.estaPressionado) avanco += 1f;
        if (btnTras != null && btnTras.estaPressionado) avanco -= 1f;
        if (btnEsquerda != null && btnEsquerda.estaPressionado) giro -= 1f;
        if (btnDireita != null && btnDireita.estaPressionado) giro += 1f;

        // Aplica o giro horizontal (eixo Y)
        if (giro != 0f)
        {
            float angulo = giro * velocidadeGiroBase * multiplicadorSensibilidade * Time.fixedDeltaTime;
            rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, angulo, 0f));
        }

        // Aplica o deslocamento para frente ou para trás
        if (avanco != 0f)
        {
            Vector3 movimento = transform.forward * avanco * velocidadeBase * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + movimento);
        }
    }

    // Atualiza o ponto de recuperação seguro (recovery_point)
    public void RegistrarPontoRecuperacao(Vector3 novaPosicao, Quaternion novaRotacao)
    {
        posicaoSeguraAtual = novaPosicao;
        rotacaoSeguraAtual = novaRotacao;
    }

    // Reposiciona o robô sem punição caso trave ou o jogador peça ajuda
    public void RecuperarPosicao()
    {
        rb.linearVelocity = Vector3.zero;
        transform.position = posicaoSeguraAtual;
        transform.rotation = rotacaoSeguraAtual;
    }
}