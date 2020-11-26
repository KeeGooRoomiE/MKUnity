using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class AreasRemoving : MonoBehaviour, IEndDragHandler
{
    [SerializeField] private GameObject target; 

    public void OnEndDrag(PointerEventData eventData) {
        //Debug.Log("Close location images");
        target.SetActive(false);
    }
}
