﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour {
    public static int lives = 10;

    PlayerStats player1;
    PlayerStats player2;
    PlayerStats player3;
    PlayerStats player4;

    public static void GameOver()
    {
        GameStats.lives--;
        if (GameStats.lives <= 0)
        {
            GameStats.lives = 0;
            print("GameOver");
        }
    }
}

public class PlayerStats
{
    public int score;
    public int money;
}