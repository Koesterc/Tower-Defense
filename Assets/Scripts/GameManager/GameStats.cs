using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour {
    [SerializeField]
    int m_lives = 10;
    public int lives { get { return m_lives; } set { m_lives = value; GameManager.ui.generalStats.lives.text = "Lives: "+m_lives.ToString(); } } 

    public PlayerStats playerStats;
    //PlayerStats player2;
   // PlayerStats player3;
   // PlayerStats player4;

    public void GameOver()
    {
        lives--;
        if (lives <= 0)
        {
            lives = 0;
            print("GameOver");
        }
    }

    [System.Serializable]
    public class PlayerStats
    {
        int m_score;
        public int score { get { return m_score; } set { m_score = value; GameManager.ui.generalStats.score.text = "Score: "+"$"+m_score.ToString(); } }
        int m_money;
        public int money { get { return m_money; } set { m_money = value; GameManager.ui.generalStats.money.text = "Money: " + "$" + m_money.ToString(); } }
        public int income;
        public int upkeep;
        public float incomeRate = 15f;

        public PlayerSkills playerSkills;

        public class PlayerSkills
        {

        }
    }
}

