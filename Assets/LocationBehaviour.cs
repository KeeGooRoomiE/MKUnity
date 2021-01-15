using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LocationBehaviour : MonoBehaviour, IPointerDownHandler
{

    [SerializeField] public LocPanelBehaviour panel;
    [SerializeField] public Image image;
    [SerializeField] private float activeAlpha;
    [SerializeField] private float inactiveAlpha;
    [SerializeField] private bool isSelected;
    [SerializeField] public int locNum;
    [SerializeField] public int locGrowth;
    [SerializeField] private int maxGrowth;
    [SerializeField] public int locRep;
    [SerializeField] private int maxRep;
    [SerializeField] private Color tmpCol;

    void Start() {
        image = GetComponent<Image>();

        tmpCol = image.color;
        activeAlpha = 0.5f;
        inactiveAlpha = 0.01f;

        locGrowth = 10;
        locRep = 10;

        maxGrowth = 100;
        maxRep = 100;

        var loc = GetComponent<LocationTriggerCollider>();
        locNum = loc.locationNumber;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isSelected == true) {
            isSelected = false;
            panel.ClearLocation();
        } else {
            isSelected = true;
            panel.SetLocation(gameObject);
            tmpCol.a = activeAlpha;
            image.color = tmpCol;
        }
    }

    void Update() {
        if (panel.curLoc != gameObject) {
            tmpCol.a = inactiveAlpha;
            image.color = tmpCol;
        }
    }

    public void AddRep(int value) {
        if (locRep+value <= maxRep) {
            locRep += value;
            panel.UpdateLocation(gameObject);
            Debug.Log("To a location " + locNum + " was added a " + value + " rep");
            Debug.Log("Location" + locNum + " has "+ locRep + "/" + maxRep + " reputation");
        } else {
            panel.UpdateLocation(gameObject);
            Debug.Log("cant add location reputation due to max value");
            Debug.Log("Location" + locNum + " has "+ locRep + "/" + maxRep + " reputation");
        }
    }

    public void DivRep(int value) {
        if (locRep-value >= 0) {
            locRep -= value;
            panel.UpdateLocation(gameObject);
            Debug.Log("To a location " + locNum + " was decremented a " + value + " rep");
            Debug.Log("Location" + locNum + " has "+ locRep + "/" + maxRep + " reputation");
        } else {
            panel.UpdateLocation(gameObject);
            Debug.Log("cant decrement location reputation due to min value");
            Debug.Log("Location" + locNum + " has "+ locRep + "/" + maxRep + " reputation");
        }
    }
}
