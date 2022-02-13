using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsTracker : MonoBehaviour
{
    public static StatsTracker instance;

    // basicAchievments
    public AchievementUnlock basicMouvement;
    public AchievementUnlock basicJump;
    public AchievementUnlock basicCoin;
    public AchievementUnlock basicKill;
    public AchievementUnlock basicCheckpoint;

    // basicAchievments
    public AchievementUnlock easyCoin;
    public AchievementUnlock easyApple;
    public AchievementUnlock easyDeath;
    public AchievementUnlock easyDrown;
    public AchievementUnlock easyKill;
    public AchievementUnlock easyRest;
    public AchievementUnlock easyCheckpoint;

    // mediumAchievments
    public AchievementUnlock mediumCoin;
    public AchievementUnlock mediumKill;
    public AchievementUnlock mediumDBKill;
    public AchievementUnlock mediumBurn;
    public AchievementUnlock mediumFly;
    public AchievementUnlock mediumDodge;
    public AchievementUnlock mediumCheckpoint;

    // stats
    [HideInInspector] public int coins = 0;
    [HideInInspector] public int jump = 0;
    [HideInInspector] public int gKill = 0;
    [HideInInspector] public int fKill = 0;
    [HideInInspector] public int totalKill = 0;
    [HideInInspector] public int water = 0;
    [HideInInspector] public int lava = 0;
    [HideInInspector] public int apple = 0;
    [HideInInspector] public int death = 0;
    [HideInInspector] public float rest = 0;
    [HideInInspector] public float metter = 0;
    [HideInInspector] public int killStreak = 0;
    [HideInInspector] public float dodge = 0;
    [HideInInspector] public bool allHoleExplored = false;

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
        basicAchievementCheck();
        easyAchievementCheck();
        mediumAchievementCheck();
        GameObject[] holes = GameObject.FindGameObjectsWithTag("Hole");
        allHoleExplored = true;
        foreach (GameObject hole in holes)
        {
            if (hole.gameObject.GetComponent<Hole>().Explored == false)
                allHoleExplored = false;
        }
        dodge += Time.deltaTime;

    }



    private void basicAchievementCheck()
    {
        if(metter >= 1 && !basicMouvement.unlocked)
        {
            basicMouvement.Unlock();
        }
        if (jump >= 1 && !basicJump.unlocked)
        {
            basicJump.Unlock();
        }
        if (coins >= 1 && !basicCoin.unlocked)
        {
            basicCoin.Unlock();
        }
        if (totalKill >= 1 && !basicKill.unlocked)
        {
            basicKill.Unlock();
        }
        if (!basicCheckpoint.unlocked &&
            basicMouvement.unlocked &&
            basicJump.unlocked &&
            basicKill.unlocked &&
            basicCoin.unlocked
        )
        {
            basicCheckpoint.Unlock();
        }
    }


    private void easyAchievementCheck()
    {
        if (coins >= 10 && !easyCoin.unlocked)
        {
            easyCoin.Unlock();
        }
        if (totalKill >= 10 && !easyKill.unlocked)
        {
            easyKill.Unlock();
        }
        if (apple >= 1 && !easyApple.unlocked)
        {
            easyApple.Unlock();
        }
        if (death >= 1 && !easyDeath.unlocked)
        {
            easyDeath.Unlock();
        }
        if (water >= 1 && !easyDrown.unlocked)
        {
            easyDrown.Unlock();
        }
        if (rest >= 10 && !easyRest.unlocked)
        {
            easyRest.Unlock();
        }

        if (!easyCheckpoint.unlocked &&
            easyCoin.unlocked &&
            easyKill.unlocked &&
            easyApple.unlocked &&
            easyDeath.unlocked &&
            easyDrown.unlocked &&
            easyRest.unlocked
        )
        {
            easyCheckpoint.Unlock();
        }
    }

    private void mediumAchievementCheck()
    {
        if (coins >= 25 && !mediumCoin.unlocked)
        {
            mediumCoin.Unlock();
        }
        if (totalKill >= 25 && !mediumKill.unlocked)
        {
            mediumKill.Unlock();
        }
        if (killStreak >= 2 && !mediumDBKill.unlocked)
        {
            mediumDBKill.Unlock();
        }
        if (lava >= 1 && !mediumBurn.unlocked)
        {
            mediumBurn.Unlock();
        }
        if (fKill >= 1 && !mediumFly.unlocked)
        {
            mediumFly.Unlock();
        }


        if (dodge >= 30 && !mediumDodge.unlocked)
        {
            mediumDodge.Unlock();
        }

        if (!mediumCheckpoint.unlocked &&
            mediumCoin.unlocked &&
            mediumKill.unlocked &&
            mediumDBKill.unlocked &&
            mediumBurn.unlocked &&
            mediumFly.unlocked &&
            mediumDodge.unlocked
        )
        {
            mediumCheckpoint.Unlock();
        }
    }

    /*private void advancedAchievementCheck()
    {
        if (coins >= 25 && !advancedCoin.unlocked)
        {
            advancedCoin.Unlock();
        }
        if (totalKill >= 25 && !advancedKill.unlocked)
        {
            advancedKill.Unlock();
        }
        if (killStreak >= 2 && !advancedDBKill.unlocked)
        {
            advancedDBKill.Unlock();
        }
        if (lava >= 1 && !advancedBurn.unlocked)
        {
            advancedBurn.Unlock();
        }
        if (fKill >= 1 && !advancedFly.unlocked)
        {
            advancedFly.Unlock();
        }


        if (dodge >= 30 && !advancedDodge.unlocked)
        {
            advancedDodge.Unlock();
        }

        if (!advancedCheckpoint.unlocked &&
            advancedCoin.unlocked &&
            advancedKill.unlocked &&
            advancedDBKill.unlocked &&
            advancedBurn.unlocked &&
            advancedFly.unlocked &&
            advancedDodge.unlocked
        )
        {
            advancedCheckpoint.Unlock();
        }
    }*/













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
    public void addWater(int count)
    {
        water += count;
    }
    public void addLava(int count)
    {
        lava += count;
    }
    public void addApple(int count)
    {
        apple += count;
    }
    public void addMeter(float count)
    {
        metter += count;
    }
    public void addDeath(int count)
    {
        death += count;
    }
}
