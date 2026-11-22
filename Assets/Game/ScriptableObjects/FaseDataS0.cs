using UnityEngine;

// Essa linha cria uma opção nova no menu do botão direito do Unity!
[CreateAssetMenu(fileName = "NovaFase", menuName = "HelpIR/Dados da Fase")]
public class FaseDataSO : ScriptableObject
{
    [Header("1. Identificação Visual (Sem Textos Longos)")]
    public int numeroFase;                  // 0 para o Tutorial, 1, 2, 3... para as demais
    public bool ehTutorial;                 // Marque verdadeiro apenas na Fase 0
    public Sprite iconeSetorPrincipal;      // Ícone grande para representar a fase no card
    public Color corDestaqueSetor = Color.white; // Cor suave da borda/fundo do card

    [Header("2. Parâmetros de Dificuldade (Level Design)")]
    public float velocidadeRobo = 3f;       // robot_speed: velocidade de deslocamento
    public int quantidadeSetores = 3;       // num_sectors_active: setores ativos (3 a 6)
    public int entregasParaVencer = 5;      // max_deliveries: quantas entregas concluem a fase

    [Header("3. Perturbações / Obstáculos Progressivos")]
    public bool temFumacaNasPlacas;         // Ativa ocultação visual nas placas
    [Range(0f, 1f)]
    public float densidadeFumaca = 0f;      // smoke_density: 0 (limpo) a 1 (totalmente oculta)
    public bool temCorredoresBloqueados;    // Ativa bloqueio dinâmico de caminhos
    public int quantidadeBloqueios = 0;     // Quantos corredores bloqueáveis fecham (0 a 3)

    [Header("4. Cena de Destino")]
    public string nomeCenaGameplay = "Gameplay";
}