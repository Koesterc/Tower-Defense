using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour {
    [SerializeField]
    int poolNumber = 10;
    [SerializeField]
    GameObject bullet;
    List<GameObject> bulletList = new List<GameObject>();
    int bulletIndex = 0;

    // Use this for initialization
    void Start () {
        for (int i = 0; i < poolNumber; i++)
        {
            Create();
        }
    }

    public GameObject Spawn(Vector3 inPosition, Quaternion inRotaton, float duration)
    {
        if (bulletList[(bulletIndex+1) % bulletList.Count].activeSelf)
        {
            Create();
            bulletIndex = bulletList.Count-1;
        }
        else
            bulletIndex++;
        bulletList[bulletIndex % bulletList.Count].transform.position = inPosition;
        bulletList[bulletIndex % bulletList.Count].transform.rotation = inRotaton;
        bulletList[bulletIndex % bulletList.Count].SetActive(true);
        StartCoroutine(DisableBullet(duration, bulletList[bulletIndex % bulletList.Count]));
        return bulletList[bulletIndex%bulletList.Count];
    }

    void Create()
    {
        GameObject clone = Instantiate(bullet, transform.position, transform.rotation);
        clone.name = "Bullet";
        bulletList.Add(clone);
        clone.transform.SetParent(transform);
        clone.SetActive(false);
    }
	
	IEnumerator DisableBullet(float duration, GameObject bullet)
    {
        yield return new WaitForSeconds(duration);
        bullet.SetActive(false);
    }
}
