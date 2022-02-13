using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsTracker : MonoBehaviour
{
    public static StatsTracker instance;

    // stats
    public int coins = 0;
    public int jump = 0;
    public int gKill = 0;
    public int fKill = 0;
    public int totalKill = 0;
    public bool allHoleExplored = false;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de StatTracker dans la scène");
            return;
        }

        instance = this;
    }

    private void Update()
    {
        GameObject[] holes = GameObject.FindGameObjectsWithTag("Hole");
        allHoleExplored = true;
        foreach (GameObject hole in holes)
        {
            if (hole.gameObject.GetComponent<Hole>().Explored == false)
                allHoleExplored = false;
        }

    }

    public void addCoin(int count)
    {
        coins += count;
    }

    public void addJump(int count)
    {
        jump += count;
    }

    public void addGKill(int count)
    {
        gKill += count;
        totalKill += count;
    }
    public void addFKill(int count)
    {
        fKill += count;
        totalKill += count;
    }
}
