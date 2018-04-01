using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour {
    public int lives = 10;

    PlayerStats player1;
    PlayerStats player2;
    PlayerStats player3;
    PlayerStats player4;

    public void GameOver()
    {
        lives--;
        if (lives <= 0)
        {
            lives = 0;
            print("GameOver");
        }
    }
}

public class PlayerStats
{
    public int score;
    public int money;
}
