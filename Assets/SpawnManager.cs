using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    public static List<Transform> enemyList = new List<Transform>();
    public int enemies = 5;
    public int waves = 5;
    public GameObject Enemy;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(Spawn());
	}

    IEnumerator Spawn()
    {
        for (int i = 0; i < waves; i++)
        {
            for (int j = 0; j < enemies; j++)
            {
                yield return new WaitForSeconds(.8f);
                GameObject foe = Instantiate(Enemy, WayPoints.checkPoints[0].position, transform.rotation);
                enemyList.Add(foe.transform);
                foe.name = "Enemy";
            }
            yield return new WaitForSeconds(5f);
        }
    }
}
