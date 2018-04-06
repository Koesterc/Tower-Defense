using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StoreItem : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    GameObject tower;
    [SerializeField]
    int price;
    [SerializeField]
    string description;


    public void OnDrag(PointerEventData eventData)
    {
        
    }
    public void OnBeginDrag(PointerEventData eventData)
    {

    }
    public void OnEndDrag(PointerEventData eventData)
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.storeManager.curSelected = tower;
        GameManager.nodeController.EnableNodes();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //display results in the tooltip
        transform.localScale = new Vector3(1.5f, 1.5f, 1f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
