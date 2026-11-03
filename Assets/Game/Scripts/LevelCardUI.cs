using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelCardUI : MonoBehaviour
{
    [Header("Componentes de UI")]
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private Image thumbnailImage;
    [SerializeField] private Button playButton;
    [SerializeField] private GameObject lockOverlay;

    private LevelData currentLevelData;

    /// <summary>
    /// Configura o cartão com os dados do ScriptableObject
    /// </summary>
    public void SetupCard(LevelData data)
    {
        currentLevelData = data;

        if (titleText != null) titleText.text = data.levelTitle;
        if (descriptionText != null) descriptionText.text = data.levelDescription;
        if (thumbnailImage != null && data.levelThumbnail != null)
            thumbnailImage.sprite = data.levelThumbnail;

        // Configura o estado de bloqueio/desbloqueio
        bool unlocked = data.isUnlocked;
        if (lockOverlay != null) lockOverlay.SetActive(!unlocked);
        if (playButton != null) playButton.interactable = unlocked;

        // Limpa listeners antigos e adiciona a ação de clique
        playButton.onClick.RemoveAllListeners();
        playButton.onClick.AddListener(OnPlayButtonClicked);
    }

    private void OnPlayButtonClicked()
    {
        if (currentLevelData != null && !string.IsNullOrEmpty(currentLevelData.sceneToLoad))
        {
            // Opcional: Salvar a referência da fase atual em um GameManager antes de carregar
            SceneManager.LoadScene(currentLevelData.sceneToLoad);
        }
    }
}