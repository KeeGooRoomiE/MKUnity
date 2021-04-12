using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using static Initializator;

/*
This script is used to handle DnD functions only.
19.12.2020

 - CanvasGroup is used to block\deblock raycasts
 - RectTransform is used to manipulate object's position
 - Canvas is used to fix scale factor and make dragging more clear
*/

public class DnDItem : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private CapsuleCollider2D collider;
    [SerializeField] private Canvas canvas; 

    //get index
    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        collider = GetComponent<CapsuleCollider2D>();
    }

    //handle dnd
    public void OnBeginDrag(PointerEventData eventData) {
        canvasGroup.blocksRaycasts = false;
        collider.isTrigger = false;
        //Debug.Log("Changing global var to true");
        Global.isUnitDragging = true;
        Global.draggingUnit = gameObject;
        //Debug.Log(Global.isUnitDragging);
    }

    //while dnd
    public void OnDrag(PointerEventData eventData) {
        rectTransform.anchoredPosition += eventData.delta/ canvas.scaleFactor;
        //Global.isUnitDragging = true;
        //Debug.Log(Global.isUnitDragging);
    }

    //while drop
    public void OnDrop(PointerEventData eventData) {
        //Debug.Log("OnDrop");
    }

    //ending dnd
    public void OnEndDrag(PointerEventData eventData) {
        canvasGroup.blocksRaycasts = true;
        collider.isTrigger = true;
        //Debug.Log("Changing global var to false");
        Global.draggingUnit = null;
        Global.isUnitDragging = false;
        //Debug.Log(Global.isUnitDragging);
    }

    
    public void OnPointerDown(PointerEventData eventData) {
        //Debug.Log("OnPointerDown");
    }
}
