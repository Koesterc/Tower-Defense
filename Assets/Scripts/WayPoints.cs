using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour {
    public static List<Transform> checkPoints = new List<Transform>();

	// Use this for initialization
	void Awake () {
		foreach(Transform checkPoint in transform)
        {
            checkPoints.Add(checkPoint);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
