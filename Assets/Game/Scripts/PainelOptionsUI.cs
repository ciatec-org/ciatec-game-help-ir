using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PainelOptionsUI : MonoBehaviour
{
    [Header("Controles de Áudio")]
    [SerializeField] private Slider sliderBGM;
    [SerializeField] private Toggle toggleBGM;
    [SerializeField] private Slider sliderSFX;

    [Header("Paleta de Cores")]
    [SerializeField] private TMP_Dropdown dropdownPaleta;

    [Header("Controles e Sensibilidade")]
    [SerializeField] private TMP_Dropdown dropdownControle;
    [SerializeField] private Slider sliderSensibilidade;

    // Executa toda vez que o PainelOptions é aberto na tela
    void OnEnable()
    {
        if (SettingsManager.Instance == null) return;

        // Atualiza os elementos visuais com os valores salvos no SettingsManager
        sliderBGM.SetValueWithoutNotify(SettingsManager.Instance.bgm_volume);
        toggleBGM.SetIsOnWithoutNotify(SettingsManager.Instance.bgm_enabled);
        sliderBGM.interactable = SettingsManager.Instance.bgm_enabled;

        sliderSFX.SetValueWithoutNotify(SettingsManager.Instance.audio_volume);
        dropdownPaleta.SetValueWithoutNotify(SettingsManager.Instance.paletaCoresIndex);

        dropdownControle.SetValueWithoutNotify((int)SettingsManager.Instance.control_scheme);
        AtualizarSliderSensibilidade();
    }

    public void MudarVolumeBGM(float valor)
    {
        SettingsManager.Instance.bgm_volume = valor;
        SettingsManager.Instance.AtualizarVolumesNoMixer();
    }

    public void AlternarMusicaAtiva(bool ligada)
    {
        SettingsManager.Instance.bgm_enabled = ligada;
        sliderBGM.interactable = ligada; // Bloqueia a barra se a música estiver mutada
        SettingsManager.Instance.AtualizarVolumesNoMixer();
    }

    public void MudarVolumeSFX(float valor)
    {
        SettingsManager.Instance.audio_volume = valor;
        SettingsManager.Instance.AtualizarVolumesNoMixer();
    }

    public void MudarPaletaCores(int indice)
    {
        SettingsManager.Instance.paletaCoresIndex = indice;
    }

    public void MudarEsquemaControle(int indice)
    {
        SettingsManager.Instance.control_scheme = (EsquemaControle)indice;
        // Atualiza o slider de sensibilidade para mostrar o valor daquele dispositivo
        AtualizarSliderSensibilidade();
    }

    public void MudarSensibilidade(float valor)
    {
        EsquemaControle atual = SettingsManager.Instance.control_scheme;

        if (atual == EsquemaControle.Mouse)
            SettingsManager.Instance.input_gain_mouse = valor;
        else if (atual == EsquemaControle.Touch)
            SettingsManager.Instance.input_gain_touch = valor;
        else
            SettingsManager.Instance.input_gain_keyboard = valor;
    }

    private void AtualizarSliderSensibilidade()
    {
        sliderSensibilidade.SetValueWithoutNotify(SettingsManager.Instance.ObterSensibilidadeAtiva());
    }
}