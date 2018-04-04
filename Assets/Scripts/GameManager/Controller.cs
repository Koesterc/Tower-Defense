using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    public BaseTowers curSelected;
    public delegate void PayDay();
    public event PayDay payDay;

    //sounds
    AudioController notEnoughMoney;
    AudioController maxedOut;
    AudioController upgradeSound;

    private void Start()
    {
        InvokeRepeating("Income", 0, GameManager.gameStats.playerStats.incomeRate);
        notEnoughMoney = transform.Find("Sounds/NotEnoughMoney").GetComponent<AudioController>();
        upgradeSound = transform.Find("Sounds/UpgradeSound").GetComponent<AudioController>();
        maxedOut = transform.Find("Sounds/MaxedOut").GetComponent<AudioController>();
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
        DefenseTowers dt = curSelected.gameObject.GetComponent<DefenseTowers>();

        if (dt.firePower.upgrade.curLvl >= dt.firePower.upgrade.maxLvl)
        {
            maxedOut.Play();
            return;
        }
        upgradeSound.Play();
        dt.firePower.damage += dt.firePower.upgrade.damage;
        dt.firePower.upgrade.curLvl++;
    }
    public void UpgradeRange()
    {
        DefenseTowers dt = curSelected.GetComponent<DefenseTowers>();

        if (dt.weaponRate.upgrade.curLvl >= dt.weaponRate.upgrade.maxLvl)
        {
            maxedOut.Play();
            return;
        }
        upgradeSound.Play();
        dt.weaponRate.fireRate -= dt.weaponRate.upgrade.fireRate;
        dt.weaponRate.upgrade.curLvl++;
    }
    public void UpgradeFireRate()
    {
        DefenseTowers dt = curSelected.GetComponent<DefenseTowers>();

        if (dt.weaponRange.upgrade.curLvl >= dt.weaponRange.upgrade.maxLvl)
        {
            maxedOut.Play();
            return;
        }
        upgradeSound.Play();
        dt.weaponRange.range += dt.weaponRange.upgrade.range;
        dt.weaponRange.upgrade.curLvl++;
    }

    public void UpgradeIncome()
    {
        BankTower bank = curSelected.gameObject.GetComponent<BankTower>();

        if (bank.curIncomeLvl >= bank.maxIncomeLvl)
        {
            maxedOut.Play();
            return;
        }
        upgradeSound.Play();
        bank.income += bank.incomeIncrement;
        bank.curIncomeLvl++;
    }


    //AI States
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
