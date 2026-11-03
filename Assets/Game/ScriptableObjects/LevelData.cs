using UnityEngine;

[CreateAssetMenu(fileName = "Fase_00", menuName = "HelpIR/Dados de Fase")]
public class LevelData : ScriptableObject
{
    [Header("Informações de Exibição (UI)")]
    public int levelIndex;
    public string levelTitle;
    
    [TextArea(3, 5)]
    public string levelDescription; // Descrição ou dica visual
    public Sprite levelThumbnail;    // Imagem/ícone da fase

    [Header("Parâmetros do Gameplay")]
    public string sceneToLoad;
    public float robotSpeed = 5f;

    [Range(0f, 1f)] public float smokeDensity = 0f; // Perturbação visual (GP-03)
    public int maxDeliveries = 10;
    
    [Header("Estado de Progresso")]
    public bool isUnlocked = true;
}