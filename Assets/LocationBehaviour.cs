using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using static Initializator;

public class LocationBehaviour : MonoBehaviour, IPointerDownHandler
{

    #region //Init values
    [SerializeField] public LocPanelBehaviour panel;            //location panel GUI element link
    [SerializeField] private LocationTriggerCollider loc;       //location script
    [SerializeField] public Sprite[] sprites;                   //array of sprites assigned to that location
    [SerializeField] public Sprite[] selection;                 //array of selection sprites to that location
    [SerializeField] public Image selectionImage;               //selection Image component link
    [SerializeField] public Image locationImage;                //location Image component link
    [SerializeField] public int state;                          //Current state of the location
    [SerializeField] public int selState;                       //Current selection state of the location
    //[SerializeField] private float activeAlpha;
    //[SerializeField] private float inactiveAlpha;
    [SerializeField] private bool isSelected;                   //bool for location selection
    [SerializeField] public int locNum;                         //location number to script behaviours
    [SerializeField] public int locGrowth;                      //current Growth value
    [SerializeField] private int maxGrowth;                     //max Growth value
    [SerializeField] public int locRep;                         //current Reputation value
    [SerializeField] private int maxRep;                        //max Reputation value
    [SerializeField] private Color tmpCol;                      //temp variable for color
    #endregion

    #region //init variables
    void Start() {

        locationImage = GetComponent<Image>();
        //var loc = GetComponent<LocationTriggerCollider>();
        locNum = loc.locationNumber;
        state = 0;
        selState = 0;

        tmpCol = locationImage.color;
        locGrowth = 10;
        locRep = 10;
        maxGrowth = 100;
        maxRep = 100;
    }
    #endregion

    #region //When pressed on a location
    public void OnPointerDown(PointerEventData eventData)
    {
        if (isSelected == true) {
            isSelected = false;
            selState = 0;
            panel.ClearLocation();
        } else {
            isSelected = true;
            selState = 1;
            panel.SetLocation(gameObject);
            //tmpCol.a = //activeAlpha;
            //image.color = tmpCol;
        }
    }
    #endregion

    #region //Self-updating behaviour
    void Update() {

        /*
        Location have proper states, wich are:
        SELECTION STATES:
        0 --- IDLE ---          common visual appearance on the map
        1 --- SELECTED ---      selected area by the player
        2 --- BLOCKED ---       unavailable area for some reason(means unit cannot be placed over there)
        LOCATION STATES:
        0 --- AlLIED ---        settled area by the allied forces
        1 --- ENEMY ---         occupied area by enemy forces
        2 --- FOW ---       WIP area that at the moment is under of the fog of war
        */

        //set proper image to different states
        locationImage.sprite = sprites[state];
        selectionImage.sprite = selection[selState];

        //increase alpha if loc state is changed 
        if (state != 0) {
            tmpCol.a = 1f;
            locationImage.color = tmpCol;
        } else {
            tmpCol.a = 0.01f;
            locationImage.color = tmpCol;
        }

        //increase alpha if sel state is changed
        if (selState != 0) {
            tmpCol.a = 1f;
            selectionImage.color = tmpCol;
        } else {
            tmpCol.a = 0.01f;
            selectionImage.color = tmpCol;
        }

        //unselect location if selected other
        if (panel.curLoc != gameObject) {
            selState = 0;
        }

        //visual unavailability for location
        if (Global.isUnitDragging == true) {
            Debug.Log("// CHECKING GLOBAL FOR TRUE");
            if (loc.playerUnit != null) {
                Debug.Log("// PLAYER IS EXIST");
                Debug.Log("// PLAYER LOC: "+Global.draggingUnit.GetComponent<InitUnit>().currentLoc);
                Debug.Log("// LOC LOC: "+loc.locationNumber);
                if (Global.draggingUnit.GetComponent<InitUnit>().currentLoc != loc.locationNumber) {
                    Debug.Log("// SET STATE 2");
                    //if player exists on a location
                    selState = 2;
                }
            }
        }
    }
    #endregion

    #region //function to increment a reputation
    public void AddRep(int value) {
        if (locRep+value <= maxRep) {
            locRep += value;
            panel.UpdateLocation(gameObject);
            //Debug.Log("To a location " + locNum + " was added a " + value + " rep");
            //Debug.Log("Location" + locNum + " has "+ locRep + "/" + maxRep + " reputation");
        } else {
            panel.UpdateLocation(gameObject);
            //Debug.Log("cant add location reputation due to max value");
            //Debug.Log("Location" + locNum + " has "+ locRep + "/" + maxRep + " reputation");
        }
    }
    #endregion

    #region //function to decrement a reputation
    public void DivRep(int value) {
        if (locRep-value >= 0) {
            locRep -= value;
            panel.UpdateLocation(gameObject);
            //Debug.Log("To a location " + locNum + " was decremented a " + value + " rep");
            //Debug.Log("Location" + locNum + " has "+ locRep + "/" + maxRep + " reputation");
        } else {
            panel.UpdateLocation(gameObject);
            //Debug.Log("cant decrement location reputation due to min value");
            //Debug.Log("Location" + locNum + " has "+ locRep + "/" + maxRep + " reputation");
        }
    }
    #endregion

    #region //function to increment a growth
    public void AddGrowth(int value) {
        state = 1;
        if (locGrowth+value <= maxGrowth) {
            locGrowth += value;
            panel.UpdateLocation(gameObject);
            //Debug.Log("To a location " + locNum + " was added a " + value + " growth");
            //Debug.Log("Location" + locNum + " has "+ locGrowth + "/" + maxGrowth + " growth");
        } else {
            panel.UpdateLocation(gameObject);
            //Debug.Log("cant add location growth due to max value");
            //Debug.Log("Location" + locNum + " has "+ locGrowth + "/" + maxGrowth + " growth");
        }
    }
    #endregion

    #region //function to decrement a growth
    public void DivGrowth(int value) {
        state = 2;
        if (locGrowth-value >= 0) {
            locGrowth -= value;
            panel.UpdateLocation(gameObject);
            //Debug.Log("To a location " + locNum + " was decremented a " + value + " growth");
            //Debug.Log("Location" + locNum + " has "+ locGrowth + "/" + maxGrowth + " growth");
        } else {
            panel.UpdateLocation(gameObject);
            //Debug.Log("cant div location growth due to max value");
            //Debug.Log("Location" + locNum + " has "+ locGrowth + "/" + maxGrowth + " growth");
        }
    }
    #endregion
}
