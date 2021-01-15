using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepPanelBehaviour : MonoBehaviour
{
    [SerializeField] public Text text;
    [SerializeField] public LocationBehaviour[] location;
    [SerializeField] public GameObject debugPlane;
    [SerializeField] public int zoneRep;
    [SerializeField] private int tempZoneRep;

    // Update is called once per frame
    //void Update() {
    public void UpdateRep() {    
        //try to count overall reputation across all locations
        //foreach (LocationBehaviour loc in location) {
        tempZoneRep = 0;
        
        for (var i = 0; i < location.Length; i++) {
            
            tempZoneRep += location[i].locRep;
            //zoneRep = location[i].locRep;
            //zoneRep += loc.locRep;
            //zoneRep = location[i]
            zoneRep = tempZoneRep / location.Length;
            //Debug.Log("ZoneRep: "+zoneRep);
        }

        text.text = "Zone Reputation: "+ zoneRep +"/100";

        if (zoneRep <= 0) {
            //make a game restart
        }

        if (zoneRep >= 100) {
            //make a game restart
            debugPlane.SetActive(true);
        }

    }
}
