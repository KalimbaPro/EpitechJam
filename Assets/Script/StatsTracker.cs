using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsTracker : MonoBehaviour
{
    public static StatsTracker instance;

    // stats
    public int coins = 0;
    public int jump = 0;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de StatTracker dans la scène");
            return;
        }

        instance = this;
    }

    public void addCoin(int count)
    {
        coins += count;
    }

    public void addJump(int count)
    {
        jump += count;
    }
}
