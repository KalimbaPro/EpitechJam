using UnityEngine;
using UnityEngine.SceneManagement;

public class Achievement : MonoBehaviour
{
    public GameObject basicAchievement;
    public GameObject easyAchievement;
    public GameObject mediumAchievement;
    public GameObject advancedAchievement;
    public GameObject legendaryAchievement;
    
    public string levelToLoad;
    
    private void setFalse()
    {
        basicAchievement.SetActive(false);
        easyAchievement.SetActive(false);
        mediumAchievement.SetActive(false);
        advancedAchievement.SetActive(false);
        legendaryAchievement.SetActive(false);
    }

    public void BasicButton()
    {
        setFalse();
        basicAchievement.SetActive(true);
    }

    public void EasyButton()
    {
        setFalse();
        easyAchievement.SetActive(true);
    }

    public void MediumButton()
    {
        setFalse();
        mediumAchievement.SetActive(true);
    }

    public void AdvancedButton()
    {
        setFalse();
        advancedAchievement.SetActive(true);
    }

    public void LegendaryButton()
    {
        setFalse();
        legendaryAchievement.SetActive(true);
    }

    public void CloseButton()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
