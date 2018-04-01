using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour {

    public GeneralStats generalStats;
    public PlayerStats playerStats;
    public TowerStats towerStats;

    public class GeneralStats {
        public TextMeshProUGUI lives;
        public TextMeshProUGUI money;
        public TextMeshProUGUI score;
    }
    public class PlayerStats
    {
        public TextMeshProUGUI name;
        public TextMeshProUGUI xp;
        public TextMeshProUGUI rank;
        public TextMeshProUGUI kills;
    }
    public class TowerStats
    {
        public TextMeshProUGUI name;
        public TextMeshProUGUI kills;
        public TextMeshProUGUI dmgLvl;
        public TextMeshProUGUI dmg;
        public TextMeshProUGUI fireRateLvl;
        public TextMeshProUGUI fireRate;
        public TextMeshProUGUI rangeLvl;
        public TextMeshProUGUI range;
        public TextMeshProUGUI sellValue;
        public Image towerIcon;
    }
}