using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject UIPanel;
    private void OnEnable()
    {
        GameEvents.onPlayerDied += ShowGameOverPanel;
    }

    private void OnDisable()
    {
        GameEvents.onPlayerDied -= ShowGameOverPanel;
    }

    private void ShowGameOverPanel()
    {
        Time.timeScale = 0f;

        UIPanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(1);
    }

    public void MainMenue()
    {
        SceneManager.LoadScene(0);
    }
}
