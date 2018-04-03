using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankTower : BaseTowers {
    public int income;

    private void Start()
    {
        GameManager.gameStats.playerStats.income += income;
        GameManager.controller.payDay += PayDay;
    }
    private void OnDestroy()
    {
        GameManager.gameStats.playerStats.income -= income;
        GameManager.controller.payDay -= PayDay;
    }


    // Use this for initialization
    public void PayDay () {
        print("earned!");
	}

    public override void IncreaseDamage()
    {
    }

    public override void IncreaseFireRate()
    {

    }

    public override void IncreaseRange()
    {
    }

}
