using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AchievementMenu : MonoBehaviour
{
    public static bool isDisplay = false;

    public GameObject achievementWindow;
    public AudioSource buttonSound;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (isDisplay)
            {
                Resume();
            }
            else
            {
                Open();
            }
        }
    }
    public void Open()
    {
        Cursor.visible = true;
        achievementWindow.SetActive(true);
        Time.timeScale = 0;
        isDisplay = true;
    }

    public void Resume()
    {
        AudioManager.instance.PlayClipAt(buttonSound.clip, transform.position, buttonSound.outputAudioMixerGroup);
        Cursor.visible = false;
        achievementWindow.SetActive(false);
        Time.timeScale = 1;
        isDisplay = false;
    }

    public void closeButton()
    {
        Resume();
    }
}
