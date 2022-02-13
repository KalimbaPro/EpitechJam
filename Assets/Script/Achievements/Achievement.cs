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

    private void open(GameObject toOpen)
    {
        setFalse();
        toOpen.SetActive(true);
    }
    public void BasicButton()
    {
        open(basicAchievement);
    }

    public void EasyButton()
    {
        open(easyAchievement);
    }

    public void MediumButton()
    {
        open(mediumAchievement);
    }

    public void AdvancedButton()
    {
        open(advancedAchievement);
    }

    public void LegendaryButton()
    {
        open(legendaryAchievement);
    }
}
