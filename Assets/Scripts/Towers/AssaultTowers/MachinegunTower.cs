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
        placed.Play();
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
        Vector3 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        rotationPart.transform.rotation = Quaternion.Slerp(rotationPart.localRotation, q, Time.deltaTime * 3);
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

    public override void IncreaseDamage()
    {
        if(firePower.upgrade.curLvl >= firePower.upgrade.maxLvl)
        {
            placed.Play();
            return;
        }
        destroyed.Play();
        firePower.damage += firePower.upgrade.damage;
        firePower.upgrade.curLvl++;
    }

    public override void IncreaseFireRate()
    {
        if (weaponRate.upgrade.curLvl >= weaponRate.upgrade.maxLvl)
        {
            placed.Play();
            return;
        }
        destroyed.Play();
        weaponRate.fireRate -= weaponRate.upgrade.fireRate;
        weaponRate.upgrade.curLvl++;
    }

    public override void IncreaseRange()
    {
        if (weaponRange.upgrade.curLvl >= weaponRange.upgrade.maxLvl)
        {
            placed.Play();
            return;
        }
        destroyed.Play();
        weaponRange.range += weaponRange.upgrade.range;
        weaponRange.upgrade.curLvl++;
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
