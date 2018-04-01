using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    public BaseTowers curSelected;

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
