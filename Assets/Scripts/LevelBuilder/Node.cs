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
        if (!GameManager.controller.selectedPurchase || isOccupied)
            return;
        if (nodeType == NodeType.Path)
            print("you can't build there");
        else
        {
            GameObject clone = Instantiate(GameManager.controller.selectedPurchase, transform.position, transform.rotation);
            //subtract from player gold
            GameManager.gameStats.playerStats.money -= clone.GetComponent<BaseTowers>().cost;
            GameManager.gameStats.playerStats.upkeep += clone.GetComponent<BaseTowers>().upKeep;
            isOccupied = true;
        }
    }

    private void OnMouseEnter()
    {
        if (isOccupied)
        {
            rend.color = GameManager.controller.invalidColor;
            return;
        }

        if (!GameManager.controller.selectedPurchase)
            return;
        if (nodeType == NodeType.Path)
            rend.color = GameManager.controller.invalidColor;
        else
            rend.color = GameManager.controller.hoverColor;
    }

    private void OnMouseExit()
    {
        if (nodeType == NodeType.Path)
            rend.color = GameManager.controller.pathColor;
        else
            rend.color = GameManager.controller.groundColor;
    }

}
