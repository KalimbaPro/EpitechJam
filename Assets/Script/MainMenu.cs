using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string levelToLoad;

    public GameObject settingsWindow;

    public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad);
        Cursor.visible = false;
    }
    public void SettingButton()
    {
        Cursor.visible = true;
        settingsWindow.SetActive(true);
    }

    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
        Cursor.visible = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
