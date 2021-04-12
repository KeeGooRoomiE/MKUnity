using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocPanelBehaviour : MonoBehaviour
{
    public GameObject[] location;
    public Text locText;
    public Text GrowthText;
    public Text RepText;
    public GameObject curLoc;
    public RepPanelBehaviour zone;
    public Image panel;
    public Color colour;

    void Start() {
        ClearLocation();
        colour.r = 1f;
        colour.g = 1f;
        colour.b = 1f;
    }

    public void SetLocation(GameObject loc) {
        curLoc = loc;
        zone.UpdateRep();
        GrowthText.text = "Growth: " + curLoc.GetComponent<LocationBehaviour>().locGrowth;
        RepText.text = "Reputation: " + curLoc.GetComponent<LocationBehaviour>().locRep;
        locText.text = "Location " + curLoc.GetComponent<LocationBehaviour>().locNum;
        colour.a = 0.4f;
        panel.color = colour;
    }

    public void UpdateLocation(GameObject loc) {
        if (curLoc != null) {
            zone.UpdateRep();
            GrowthText.text = "Growth: " + curLoc.GetComponent<LocationBehaviour>().locGrowth;
            RepText.text = "Reputation: " + curLoc.GetComponent<LocationBehaviour>().locRep;
            locText.text = "Location " + curLoc.GetComponent<LocationBehaviour>().locNum;
            colour.a = 0.4f;
            panel.color = colour;
        }
    }

    public void ClearLocation() {
        zone.UpdateRep();
        curLoc = null;
        locText.text = " ";
        GrowthText.text = " ";
        RepText.text = " ";
        colour.a = 0.0f;
        panel.color = colour;
    }
}
