using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour {

    BaseTowers tower;

    private void Start()
    {
        tower = gameObject.GetComponent<BaseTowers>();
    }

    private void OnMouseDown()
    {
        GameStats.curSelected = tower;
    }
}
