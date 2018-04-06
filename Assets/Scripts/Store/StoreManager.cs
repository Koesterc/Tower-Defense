using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour {
    public GameObject curSelected;

	public void PurchaseUnit(Vector3 pos, Quaternion rotation, Node node)
    {
        GameObject clone = Instantiate(curSelected, pos, rotation);
        clone.GetComponent<BaseTowers>().node = node;
        //subtract from player gold
        GameManager.gameStats.playerStats.money -= clone.GetComponent<BaseTowers>().cost;
        GameManager.gameStats.playerStats.upkeep += clone.GetComponent<BaseTowers>().upKeep;
        curSelected = null;
        GameManager.nodeController.DisableNodes();
    }
}
