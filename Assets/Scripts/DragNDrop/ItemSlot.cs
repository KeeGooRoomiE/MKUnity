using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour//, IDropHandler
{
     
     //[SerializeField] private GameObject target; 

    //public void OnDrop(PointerEventData eventData) {
        //Debug.Log("OnDrop");
        //if (eventData.pointerDrag != null) {
            //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            //eventData.pointerDrag.GetComponent<RectTransform>().pivot = GetComponent<RectTransform>().pivot;
        //}
    //}

    public GameObject locationObject;

    void Update() {

    }

    void OnMouseOver()
    {
        Debug.Log("Mouse is over GameObject.");
        locationObject.SetActive(true);
    }

    void OnMouseExit()
    {
        locationObject.SetActive(false);
        Debug.Log("Mouse is no longer on GameObject.");
    }
}
