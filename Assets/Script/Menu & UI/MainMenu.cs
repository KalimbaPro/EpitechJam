using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string levelToLoad;

    public GameObject settingsWindow;

    public AudioSource startSound;
    public AudioSource normalSound;
    public AudioSource exitSound;

    private IEnumerator startDelay()
    {

        yield return new WaitForSeconds(0.40f);
        SceneManager.LoadScene(levelToLoad);
        Cursor.visible = false;
    }

    public void StartGame()
    {
        StartCoroutine(startDelay());
    }

    private IEnumerator settingDelay()
    {

        yield return new WaitForSeconds(0.40f);
        Cursor.visible = true;
        settingsWindow.SetActive(true);
    }

    public void SettingButton()
    {
        StartCoroutine(settingDelay());
    }

    private IEnumerator closeSettingDelay()
    {
        yield return new WaitForSeconds(0.40f);
        settingsWindow.SetActive(false);
        Cursor.visible = true;
    }

    public void CloseSettingsWindow()
    {
        StartCoroutine(closeSettingDelay());
    }
    private IEnumerator quitDelay()
    {

        yield return new WaitForSeconds(0.40f);
        Application.Quit();
    }

    public void QuitGame()
    {
        StartCoroutine(quitDelay());
    }
}
