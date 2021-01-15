using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyGenController : MonoBehaviour
{
    [SerializeField] public GameObject[] location;
    [SerializeField] public GameObject enemyUnit;
    [SerializeField] public int GenerationValue;
    [SerializeField] public int LocationNumSelector;
    [SerializeField] private Transform parent;
    private GameObject tempUnit;
    [SerializeField] private bool[] canCreateUnit;

    private void Awake() {
        GenerationValue = Random.Range(1,100);

        for (int i = 0; i < location.Length; i++) {
            canCreateUnit[i] = false;
        }

        foreach (GameObject loccheck in location) {
            loccheck.GetComponent<LocationTriggerCollider>().isUnitExists = false;
            //Debug.Log("Location"+loccheck.GetComponent<LocationTriggerCollider>().locationNumber+".canCreateUnit = "+canCreateUnit[LocationNumSelector]+" was set to false in update");
        }
    }

    private void Update() {
        //
    }

    public void CreateUnit() {
        Debug.Log("EnemyController.CreateUnit summoned...");

        foreach (GameObject loc in location) {

            //select location from an array
            LocationNumSelector = Random.Range(0,location.Length);

            //comparing number to an array
            var locnum = LocationNumSelector + 2;

            //if location in sort and selection are the same...
            if (loc.GetComponent<LocationTriggerCollider>().locationNumber == locnum) {
                Debug.Log("Selected and random locations are the same");

                //if location if free from enemy unit...
                if (location[LocationNumSelector].GetComponent<LocationTriggerCollider>().isUnitExists == false) {

                    Debug.Log("Creating unit");
                    //create enemy unit
                    tempUnit = Instantiate(enemyUnit, parent);
                    tempUnit.transform.position = location[LocationNumSelector].transform.position;

                    //set unit index to a location object
                    location[LocationNumSelector].GetComponent<LocationTriggerCollider>().enemyUnit = tempUnit;
                    Debug.Log("Starting to change location bool...");
                    location[LocationNumSelector].GetComponent<LocationTriggerCollider>().isUnitExists = true;
                    Debug.Log("Location bool changed from there...");
                    canCreateUnit[LocationNumSelector] = false;
                } else {
                    Debug.Log("Unit already created...");
                }
            }
        }
    }
}
