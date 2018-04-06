using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeController : MonoBehaviour {
    public List<Node> nodeList = new List<Node>();

    private void Start()
    {
        foreach(Transform t in transform)
        {
            nodeList.Add(t.gameObject.GetComponent<Node>());
        }
    }

    // Use this for initialization
    public void DisableNodes () {
		foreach (Node node in nodeList){
            node.Disable();
        }
	}
    public void EnableNodes()
    {
        foreach (Node node in nodeList)
        {
            node.Enable();
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
