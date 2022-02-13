using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementUnlock : MonoBehaviour
{
    public bool unlocked = false;
    public Image background;
    public Text title;
    public Text desc;
    private Color color;

    void Update()
    {
        if (unlocked)
        {
            color = Color.white;
        } else
        {
            color = Color.gray;
        }
        background.color = color;
        title.color = color;
        desc.color = color;
    }

    public void Unlock()
    {
        unlocked = true;
    }
}
