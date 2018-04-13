using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachinegunTower : DefenseTowers {
    public Transform target;
    public Transform rotationPart;
    Animator anim;
    float lastShot;
    int shotsFired;

    public void Start()
    {
        ac = transform.Find("Sounds/Gunshots").GetComponent<AudioController>();
        destroyed = transform.Find("Sounds/Destroyed").GetComponent<AudioController>();
        placed = transform.Find("Sounds/Placed").GetComponent<AudioController>();
        anim = transform.Find("Tower").GetComponent<Animator>();
        InvokeRepeating("Seek", 0f, .5f);
    }

    void Seek(){
        float shortest = Mathf.Infinity;
        Transform nearestTarget = null;
        foreach(Transform enemy in SpawnManager.enemyList)
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
		Vector3 dir = target.transform.position - rotationPart.transform.position;
		float zRotation = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
		rotationPart.transform.rotation = Quaternion.Slerp(rotationPart.transform.rotation, 
			Quaternion.Euler (0f, 0f, zRotation - 90), Time.deltaTime * 3f);
        if (Time.time >= lastShot)
        {
            shotsFired++;
            if (shotsFired >= 5)
            {
                lastShot = Time.time + weaponRate.fireRate;
                shotsFired = 0;
            }
            else
                lastShot = Time.time + .08f;
            Fire();
        }
    }

    public override void Fire()
    {
        ac.Play();
        anim.Play("MachineGunFlash", 0, 0);
        RaycastHit hit;
        if (Physics.Raycast(rotationPart.position, target.position, out hit, 10f))
        {
            if (hit.transform.gameObject.GetComponent<Enemy>())
                hit.transform.gameObject.GetComponent<Enemy>().TakeDamage(firePower.damage);
        }
        Debug.DrawLine(rotationPart.position, target.position, Color.red, 10f);
    }

    public void OnDrawGizmosSelected()
    {
        Color c = Color.cyan;
        c.a = .1f;
        Gizmos.color = c;
        Gizmos.DrawSphere(transform.position, weaponRange.range);
    }

    //public void OnDestroy()
    //{
    //    try{
    //        destroyed.Play();
    //    }
    //    catch(Exception e)
    //    {
    //        print(e.Message);
    //    }
    //}

}
