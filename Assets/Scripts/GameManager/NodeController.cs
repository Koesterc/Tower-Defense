using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeController : MonoBehaviour {
    public List<Node> nodeList = new List<Node>();
    [SerializeField]
    GameObject nodes;

    private void Start()
    {
        foreach(Transform t in nodes.transform)
        {
            nodeList.Add(t.gameObject.GetComponent<Node>());
        }
    }

    // Use this for initialization
    public void DisableNodes () {
        nodes.SetActive(false);
	}
    public void EnableNodes()
    {
        nodes.SetActive(true);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
