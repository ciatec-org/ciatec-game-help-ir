using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Fase 0 (Tutorial) - Arraste o arquivo Fase_00_Tutorial aqui")]
    public FaseDataSO faseTutorialPadrao;

    [Header("Fase que será carregada na cena Gameplay")]
    public FaseDataSO faseAtualSelecionada;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Mantém a fase escolhida viva ao trocar de cena
    }

    public void SelecionarFase(FaseDataSO fase)
    {
        faseAtualSelecionada = fase;
    }

    public void SelecionarTutorial()
    {
        faseAtualSelecionada = faseTutorialPadrao;
    }
}