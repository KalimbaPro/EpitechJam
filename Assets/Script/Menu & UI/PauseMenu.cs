using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject pauseMenuUi;
    public AudioSource buttonSound;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }

    public void Paused()
    {
        Cursor.visible = true;
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void Resume()
    {
        AudioManager.instance.PlayClipAt(buttonSound.clip, transform.position, buttonSound.outputAudioMixerGroup);
        Cursor.visible = false;
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void LoadMainMenu()
    {
        Resume();
        Cursor.visible = true;
        SceneManager.LoadScene("MainMenu");
    }
}
