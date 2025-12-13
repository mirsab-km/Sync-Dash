using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Options()
    {
        Debug.Log("Options");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
