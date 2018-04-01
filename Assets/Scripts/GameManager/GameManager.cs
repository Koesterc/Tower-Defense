using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField]
    GameStats m_gameStats;
    public static GameStats gameStats;
    [SerializeField]
    SpawnManager m_spawnManager;
    public static SpawnManager spawnManager;
    [SerializeField]
    PoolManager m_poolManager;
    public static PoolManager poolManager;
    [SerializeField]
    UI m_ui;
    public static UI ui;
    [SerializeField]
    Controller m_Controller;
    public static Controller controller;


    // Use this for initialization
    void Awake () {
        gameStats = m_gameStats;
        spawnManager = m_spawnManager;
        poolManager = m_poolManager;
        ui = m_ui;
        controller = m_Controller;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
