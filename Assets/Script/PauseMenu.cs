using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject pauseMenuUi;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("oui");
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }

            isPaused = !isPaused;
    }

    void Paused()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void Resume()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void LoadMainMenu()
    {
        Resume();
        SceneManager.LoadScene("MainMenu");
    }
}
