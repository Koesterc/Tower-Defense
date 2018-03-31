using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float maxHealth = 100;
    float health;
    public int defense;
    [Range(0,20)]
    public float speed = 3f;
    Transform target;
    int wayPointIndex = 0;
    [SerializeField]
    Transform healthBar;
 

    // Use this for initialization
    void Start () {
        health = maxHealth;
        if (speed >= 20)
            speed = 20;
        target = WayPoints.checkPoints[wayPointIndex];
	}

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = target.position - transform.position;
        transform.Translate(dir.normalized * (speed * Time.deltaTime));
        if (Vector3.Distance(transform.position, target.position) < .2f)
            ChangeWayPoint();
    }
    void ChangeWayPoint()
    {
        if (wayPointIndex >= WayPoints.checkPoints.Count-1)
        {
            //checks to see if game is over
            GameStats.GameOver();
            SpawnManager.enemyList.Remove(transform);
            Destroy(gameObject);
            return;
        }
        wayPointIndex++;
        target = WayPoints.checkPoints[wayPointIndex];
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            health = 0;
            SpawnManager.enemyList.Remove(transform);
            Destroy(gameObject);
            return;
        }
        healthBar.localScale = new Vector3(health / maxHealth,1,1);
    }
}
