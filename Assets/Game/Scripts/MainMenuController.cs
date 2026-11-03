using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [Header("Painéis de UI")]
    [SerializeField] private GameObject settingsPanel;

    [Header("Configuração de Transição")]
    [Tooltip("Nome exato da cena para onde o botão Começar deve ir")]
    [SerializeField] private string gameplaySceneName = "FasesSelections";

    private void Start()
    {
        // Garante que a tela de configurações inicie fechada
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(false);
        }
    }

    /// <summary>
    /// Transita para a próxima cena (Fase 0 ou Gameplay)
    /// </summary>
    public void PlayGame()
    {
        SceneManager.LoadScene(gameplaySceneName);
    }

    /// <summary>
    /// Abre o painel em branco de configurações
    /// </summary>
    public void OpenSettings()
    {
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(true);
        }
    }

    /// <summary>
    /// Fecha o painel de configurações e retorna ao menu principal
    /// </summary>
    public void CloseSettings()
    {
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(false);
        }
    }

    /// <summary>
    /// Encerra a aplicação
    /// </summary>
    public void QuitGame()
    {
        Debug.Log("[MainMenu] Fechando o jogo...");
        
        // Funciona na build final (no Editor da Unity executa apenas o Debug.Log)
        Application.Quit();
    }
}