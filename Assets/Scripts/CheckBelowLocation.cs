using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CheckBelowLocation : MonoBehaviour, IDropHandler
{
     
     //[SerializeField] private GameObject target; 

    public void OnDrop(PointerEventData eventData) {
        //Debug.Log("FoundLocation");
        if (eventData.pointerDrag != null) {
            //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            //eventData.pointerDrag.GetComponent<RectTransform>().pivot = GetComponent<RectTransform>().pivot;
        }
    }
}