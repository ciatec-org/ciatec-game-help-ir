using UnityEngine;
using UnityEngine.Audio;

// Métodos de entrada suportados no projeto (PC e Mobile/Tablet)
public enum EsquemaControle
{
    Teclado = 0,
    Mouse = 1,
    Touch = 2
}

public class SettingsManager : MonoBehaviour
{
    // Permite que qualquer script de qualquer cena acesse este gerenciador
    public static SettingsManager Instance { get; private set; }

    [Header("Arraste o MainAudioMixer aqui no Inspector")]
    [SerializeField] private AudioMixer mainMixer;

    [Header("1. Controles e Sensibilidade (Seção 1.1)")]
    public EsquemaControle control_scheme = EsquemaControle.Teclado;
    public float input_gain_keyboard = 1.0f;
    public float input_gain_mouse = 1.0f;
    public float input_gain_touch = 1.0f;

    [Header("2. Áudio Independente (Seção 1.1 + GP-06)")]
    [Range(0.0001f, 1f)] public float audio_volume = 0.8f; // Volume dos efeitos (SFX)
    [Range(0.0001f, 1f)] public float bgm_volume = 0.5f;   // Volume da música (BGM)
    public bool bgm_enabled = true;                        // Liga/desliga só a música

    [Header("3. Paleta de Cores (GP-05)")]
    // 0 = Todas as cores | 1 = Paleta Suave (sem vermelho) | 2 = Cor Única
    public int paletaCoresIndex = 0;

    void Awake()
    {
        // Garante que exista apenas um SettingsManager vivo no jogo inteiro
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Impede que seja apagado ao trocar de cena
    }

    void Start()
    {
        AtualizarVolumesNoMixer();
    }

    public void AtualizarVolumesNoMixer()
    {
        if (mainMixer == null) return;

        // O AudioMixer trabalha em decibéis (-80dB a 0dB), por isso usamos Mathf.Log10
        float dbSFX = Mathf.Log10(Mathf.Clamp(audio_volume, 0.0001f, 1f)) * 20f;
        mainMixer.SetFloat("SFXVolume", dbSFX);

        // Se bgm_enabled estiver desmarcado, muta apenas a música (-80dB) e mantém os SFX
        float dbBGM = bgm_enabled
            ? Mathf.Log10(Mathf.Clamp(bgm_volume, 0.0001f, 1f)) * 20f
            : -80f;
        mainMixer.SetFloat("BGMVolume", dbBGM);
    }

    // Função que a cena de Gameplay vai chamar para saber a sensibilidade atual do robô
    public float ObterSensibilidadeAtiva()
    {
        if (control_scheme == EsquemaControle.Mouse) return input_gain_mouse;
        if (control_scheme == EsquemaControle.Touch) return input_gain_touch;
        return input_gain_keyboard;
    }
}