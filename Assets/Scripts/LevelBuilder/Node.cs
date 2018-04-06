using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {
    public enum NodeType { Ground, Path, Start, End };
    [SerializeField]
    NodeType m_type;
    public NodeType nodeType { get { return m_type; } set { m_type = value; } }
    private SpriteRenderer rend;
    bool isOccupied;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        if (nodeType == NodeType.Path)
            rend.color = GameManager.controller.pathColor;
        else
            rend.color = GameManager.controller.groundColor;
    }

    private void OnMouseDown()
    {
        if (!GameManager.storeManager.curSelected || isOccupied)
            return;
        if (nodeType == NodeType.Path)
            print("you can't build there");
        else
        {
            GameManager.storeManager.PurchaseUnit(transform.position, transform.rotation, this);
            print(this.m_type);
            isOccupied = true;
        }
    }

    private void OnMouseEnter()
    {
        if (!GameManager.storeManager.curSelected)
            return;
        if (isOccupied)
        {
            rend.color = GameManager.controller.invalidColor;
            return;
        }
        if (nodeType == NodeType.Path)
            rend.color = GameManager.controller.invalidColor;
        else
            rend.color = GameManager.controller.hoverColor;
    }

    private void OnMouseExit()
    {
        if (!GameManager.storeManager.curSelected)
            return;
        if (nodeType == NodeType.Path)
            rend.color = GameManager.controller.pathColor;
        else
            rend.color = GameManager.controller.groundColor;
    }
    public void Enable()
    {
        if (nodeType == NodeType.Path)
            rend.color = GameManager.controller.pathColor;
        else
            rend.color = GameManager.controller.groundColor;
    }
    public void Disable()
    {
        Color c = Color.white;
        c.a = 0;
        rend.color = c;
    }

}
