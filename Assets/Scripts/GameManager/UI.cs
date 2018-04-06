using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    public GeneralStats generalStats;
    public PlayerStats playerStats;
    public TowerStats towerStats;

    [System.Serializable]
    public class GeneralStats {
        public Text lives;
        public Text money;
        public Text score;
    }
    [System.Serializable]
    public class PlayerStats
    {
        public Text name;
        public Text xp;
        public Text rank;
        public Text kills;
    }
    [System.Serializable]
    public class TowerStats
    {
        public Text name;
        public Text kills;
        public Text dmgLvl;
        public Text dmg;
        public Text fireRateLvl;
        public Text fireRate;
        public Text rangeLvl;
        public Text range;
        public Text sellValue;
        public Image towerIcon;
    }
}