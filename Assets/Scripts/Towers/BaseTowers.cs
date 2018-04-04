using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseTowers : MonoBehaviour {

    [SerializeField]
    string m_towerName;
    public string towerName { get { return m_towerName; } set { m_towerName = value; } }

    [SerializeField]
    int m_cost;
    public int cost { get { return m_cost; } set { m_cost = value; } }

    public enum TowerType { BankTower, AssaultTower, SupportTower };

    [SerializeField]
    TowerType m_towerType;
    public TowerType towerType { get { return m_towerType; } set { m_towerType = value; } }

    [HideInInspector]
    AudioController m_placed;
    public AudioController placed { get { return m_placed; } set { m_placed = value; } }

    [HideInInspector]
    AudioController m_destroyed;
    public AudioController destroyed { get { return m_destroyed; } set { m_destroyed = value; } }
}
