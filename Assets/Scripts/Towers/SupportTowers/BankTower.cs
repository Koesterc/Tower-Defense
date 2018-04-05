using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankTower : BaseTowers {
    [SerializeField]
    int m_income;
    [SerializeField]
    int m_incomeIncrement;
    public int incomeIncrement { get { return m_incomeIncrement; } set { value = m_incomeIncrement; } }
    [SerializeField]
    int m_maxIncomeLvl;
    int m_curIncomeLvl;
    public int curIncomeLvl { get { return m_curIncomeLvl; } set { value = m_curIncomeLvl; } }
    public int income { get { return m_income; } set { value = m_income; } }
    public int maxIncomeLvl { get { return m_maxIncomeLvl; } set { value = m_maxIncomeLvl; } }

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
	}

}
