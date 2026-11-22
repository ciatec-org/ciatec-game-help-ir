using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalController : MonoBehaviour
{
    [Header("Painéis de UI")]
    [SerializeField] private GameObject painelOptions;
    [SerializeField] private GameObject painelSelecaoFases;

    public void ClicarStart()
    {
        if (painelSelecaoFases != null)
            painelSelecaoFases.SetActive(true);
    }

    public void FecharSelecaoFases()
    {
        if (painelSelecaoFases != null)
            painelSelecaoFases.SetActive(false);
    }

    public void ClicarTutorial()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.SelecionarTutorial();

        SceneManager.LoadScene("Gameplay");
    }

    public void ClicarOptions()
    {
        if (painelOptions != null)
            painelOptions.SetActive(true);
    }

    public void FecharOptions()
    {
        if (painelOptions != null)
            painelOptions.SetActive(false);
    }

    public void ClicarExit()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}