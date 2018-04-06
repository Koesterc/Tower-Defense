using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour {
    public int column;
    public int row;
    public float offSet;
    public GameObject panel;

	// Use this for initialization
	void Start () {
        Transform panels = GameObject.Find("NodeController/Nodes").transform;
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(0, 5, 0));
        transform.position = worldPoint;

        Vector3 pos = Vector3.zero;
        for (int i = 0; i < row; i++)
        {
            pos.y = 0;
            pos.x++;
            pos.x += offSet;
            GameObject clone = Instantiate(panel, pos, transform.rotation);
            clone.name = "Node";
            clone.transform.SetParent(panels, true);
            if (i == 0)
                Add(clone, Node.NodeType.End);
            for (int j = 1; j < column; j++)
            {
                pos.y++;
                pos.y += offSet;
                clone = Instantiate(panel, pos, transform.rotation);
                clone.name = "Node";
                clone.transform.SetParent(panels, true);
                if (j == column && i == row)
                    Add(clone, Node.NodeType.Start);
            }
        }
	}

    void Add(GameObject go, Node.NodeType type)
    {
        go.AddComponent<Node>();
        Node node = go.GetComponent<Node>();
        node.nodeType = type;
        print("done");

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
