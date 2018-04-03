using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    public BaseTowers curSelected;
    public delegate void PayDay();
    public event PayDay payDay;

    private void Start()
    {
        InvokeRepeating("Income", 0, GameManager.gameStats.playerStats.incomeRate);
    }

    public void Income()
    {
        GameManager.gameStats.playerStats.money += (GameManager.gameStats.playerStats.income - GameManager.gameStats.playerStats.upkeep);
        print(GameManager.gameStats.playerStats.money);
        try
        {
            payDay();
        }
        catch
        {

        }
    }

    public void UpgradeDamage()
    {
        curSelected.IncreaseDamage();
    }
    public void UpgradeRange()
    {
        curSelected.IncreaseRange();
    }
    public void UpgradeFireRate()
    {
        curSelected.IncreaseFireRate();
    }

    //AI
    public void NearestEnemy()
    {
    }
    public void FurthestEnemy()
    {
    }
    public void StrongestEnemy()
    {
    }
    public void WeakestEnemy()
    {
    }
    public void FocusEnemy()
    {
    }
}
