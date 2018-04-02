using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour {
    public int lives = 10;

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
        public int score;
        public int money;
        public int income;
        public int upkeep;
        public float incomeRate = 15f;

        public PlayerSkills playerSkills;

        public class PlayerSkills
        {

        }
    }
}

