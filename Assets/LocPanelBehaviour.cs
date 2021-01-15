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

    void Start() {
        ClearLocation();
    }

    public void SetLocation(GameObject loc) {
        curLoc = loc;
        zone.UpdateRep();
        GrowthText.text = "Growth: " + curLoc.GetComponent<LocationBehaviour>().locGrowth;
        RepText.text = "Reputation: " + curLoc.GetComponent<LocationBehaviour>().locRep;
        locText.text = "Location " + curLoc.GetComponent<LocationBehaviour>().locNum;
    }

    public void UpdateLocation(GameObject loc) {
        if (curLoc != null) {
            zone.UpdateRep();
            GrowthText.text = "Growth: " + curLoc.GetComponent<LocationBehaviour>().locGrowth;
            RepText.text = "Reputation: " + curLoc.GetComponent<LocationBehaviour>().locRep;
            locText.text = "Location " + curLoc.GetComponent<LocationBehaviour>().locNum;
        }
    }

    public void ClearLocation() {
        zone.UpdateRep();
        curLoc = null;
        locText.text = "No location selected";
        GrowthText.text = "Growth: 0";
        RepText.text = "Reputation: 0";
    }
}
