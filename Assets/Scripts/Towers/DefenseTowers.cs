using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DefenseTowers : BaseTowers {
    [Space(5)]
    [SerializeField]
    int m_kills = 0;
    public int kills{ get { return m_kills; } set { m_kills = value; } }
    public FirePower firePower;
    public WeaponRange weaponRange;
    public WeaponRate weaponRate;
    [HideInInspector]
    public AudioController ac;

    [System.Serializable]
    public class FirePower {
        [SerializeField]
        float m_damage;
        public float damage { get { return m_damage; } set { m_damage = value; } }
        public DamageUpgrades upgrade;
    }
    [System.Serializable]
    public class WeaponRange
    {
        [SerializeField]
        float m_range = 5f;
        public float range { get { return m_range; } set { m_range = value; } }
        public RangeUpgrades upgrade;
    }
    [System.Serializable]
    public class WeaponRate
    {
        [SerializeField]
        float m_fireRate = 1;
        public float fireRate { get { return m_fireRate; } set { m_fireRate = value; } }
        [SerializeField]
        float m_coolDown = .5f;
        public float coolDown { get { return m_coolDown; } set { m_coolDown = value; } }
        public RateUpgrades upgrade;
    }

    public abstract void Fire();
}


[System.Serializable]
public class DamageUpgrades
{
    [SerializeField]
    float m_damage = 1;
    public float damage { get { return m_damage; } set { m_damage = value; } }
    [SerializeField]
    int m_maxLvl = 3;
    public int maxLvl { get { return m_maxLvl; } set { m_maxLvl = value; } }
    [SerializeField]
    int m_cost = 3;
    public int cost { get { return m_cost; } set { m_cost = value; } }
}
[System.Serializable]
public class RangeUpgrades
{
    [SerializeField]
    float m_range = 1f;
    public float range { get { return m_range; } set { m_range = value; } }
    [SerializeField]
    int m_maxLvl = 3;
    public int maxLvl { get { return m_maxLvl; } set { m_maxLvl = value; } }
    [SerializeField]
    int m_cost = 3;
    public int cost { get { return m_cost; } set { m_cost = value; } }
}
[System.Serializable]
public class RateUpgrades
{
    [SerializeField]
    float m_fireRate = .1f;
    public float fireRate { get { return m_fireRate; } set { m_fireRate = value; } }
    [SerializeField]
    int m_maxLvl = 3;
    public int maxLvl { get { return m_maxLvl; } set { m_maxLvl = value; } }
    [SerializeField]
    int m_cost = 3;
    public int cost { get { return m_cost; } set { m_cost = value; } }
}
