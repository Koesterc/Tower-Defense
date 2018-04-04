using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidicTower : DefenseTowers
{
    public Transform target;
    float lastShot;
    PoolManager poolManager;

    public void Start()
    {
        poolManager = GameManager.poolManager;
        ac = transform.Find("Sounds/Gunshots").GetComponent<AudioController>();
        destroyed = transform.Find("Sounds/Destroyed").GetComponent<AudioController>();
        placed = transform.Find("Sounds/Placed").GetComponent<AudioController>();
       // placed.Play();
        InvokeRepeating("Seek", 0f, .5f);
    }

    void Seek()
    {
        float shortest = Mathf.Infinity;
        Transform nearestTarget = null;
        foreach (Transform enemy in SpawnManager.enemyList)
        {
            float distance = Vector3.Distance(transform.position, enemy.position);
            if (distance < shortest)
            {
                shortest = distance;
                nearestTarget = enemy;
            }
        }
        if (shortest <= weaponRange.range)
            target = nearestTarget;
        else
            target = null;
    }

    void Update()
    {
        if (!target)
            return;
        if (Time.time >= lastShot)
        {
          lastShot = Time.time + weaponRate.fireRate;
          Fire();
        }
    }

    public override void Fire()
    {
        ac.Play();
        GameObject clone = poolManager.Spawn(transform.position, transform.rotation, 3.5f);
        clone.GetComponent<Rigidbody>().velocity = (target.position-transform.position)*(Time.deltaTime*100f);
    }

    public void OnDrawGizmosSelected()
    {
        Color c = Color.cyan;
        c.a = .1f;
        Gizmos.color = c;
        Gizmos.DrawSphere(transform.position, weaponRange.range);
    }
}
