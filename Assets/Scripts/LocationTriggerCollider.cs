﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LocationTriggerCollider : MonoBehaviour
{
    //[SerializeField] public GameObject location;        //itself location prefab
    [SerializeField] public int locationNumber;         //counted number of that location
    [SerializeField] EnemyGenController EUController;           //enemy unit controller
    [SerializeField] private int unitCount;             //counts of units on a location
    [SerializeField] public bool isUnitExists;
    [SerializeField] public GameObject enemyUnit;
    [SerializeField] public GameObject playerUnit;
    [SerializeField] public bool bothTypeUnitsHere;
    private RectTransform rectTransform;
    [SerializeField] public bool canAddRep;
    [SerializeField] public bool canDivRep;
    [SerializeField] public bool ActiveRepChange;
    [SerializeField] public bool ActiveEnemyUnit;
    [SerializeField] private LocationBehaviour locInfo; //check another location script
    
    private void Awake() {
        //rectTransform = GetComponent<RectTransform>();
        bothTypeUnitsHere = false;
        isUnitExists = false;
        canAddRep = true;
        canDivRep = true;
        ActiveRepChange = false;
        ActiveEnemyUnit = false;
        locInfo = this.gameObject.GetComponent<LocationBehaviour>();
        }

    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Unit") {
            if (ActiveEnemyUnit == false) {
                EUController.CreateUnit();
            }
            //playerUnit = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other == playerUnit) {
            playerUnit = null;
            ActiveRepChange = false;
        }
        
    }
    
    private void OnTriggerStay2D(Collider2D other) {
        //Debug.Log("Something is collided!");
        other.GetComponent<InitUnit>().currentLoc = locationNumber;
        //Debug.Log("Set location "+locationNumber+" to a collided unit");
        
        //Debug.Log("OnTriggerColliderEnter2D called!");
        //ActiveRepChange = true;
        /*
        //check for both units
        if (isUnitExists == true) {
            //Debug.Log("Location"+locationNumber+" have enemy unit...");

            if (playerUnit != null) {
                //Debug.Log("Location"+locationNumber+" have both enemy and player units...");
                bothTypeUnitsHere = true;
                LetUnitsFight(true);
            } else {
                //Debug.Log("player unit lost while checking...");
                bothTypeUnitsHere = false;
                LetUnitsFight(false);
            }
        }
        */
    }

    IEnumerator Delay(float time) {
        yield return new WaitForSeconds(time);
        canAddRep = true;
        canDivRep = true;
    }

    void Update() {
        //ability to increment location reputation periodically
        if (ActiveRepChange == true) {
            if (canAddRep == true) {
                locInfo.AddRep(1);
                StartCoroutine(Delay(2.0f));
                canAddRep = false;
            }
        }

        //ability to decrement location reputation periodically
        if (ActiveEnemyUnit == true) {
            if (canDivRep == true) {
                locInfo.DivRep(1);
                StartCoroutine(Delay(2.0f));
                canDivRep = false;
            }
        }

        //checking for existing enemy unit on a location
        if (enemyUnit == null) {
            ActiveEnemyUnit = false;
        } else {
            ActiveEnemyUnit = true;
        }

        //checking for existing player unit on a location
        if (playerUnit == null) {
            ActiveRepChange = false;
        } else {
            ActiveRepChange = true;
        }

        //make both units make attack
        if (ActiveEnemyUnit && ActiveRepChange) {
            if (playerUnit != null) {
                if (enemyUnit != null) {
                    playerUnit.GetComponent<InitUnit>().canAttack = true;
                    playerUnit.GetComponent<InitUnit>().target = enemyUnit;
                    //enemyUnit.canAttack = true;
                    //enemyUnit.target = playerUnit;
                }
            }
        }

        if (playerUnit.GetComponent<InitUnit>().currentLoc != locationNumber) {
            ActiveRepChange = false;
            playerUnit = null;
        }

        if (enemyUnit != null) {
            if (playerUnit != null) {
                Debug.Log("Location sended to an enemy player instance");
                enemyUnit.GetComponent<EnemyUnitInit>().target = playerUnit;
            } else {
                Debug.Log("Location sended to an enemy player null");
                enemyUnit.GetComponent<EnemyUnitInit>().target = null;
            }
        }
    }
    /*

    void Update() {

        //trigger bool var if unit is empty\exists
        if (enemyUnit == null) {
            isUnitExists = false;
        } else {
            isUnitExists = true;
            //Debug.Log("Location"+locationNumber+".enemyUnit is "+enemyUnit);
        }

        
        /*
        if (playerUnit != null) {
            if (tmpUnit != null) {
                playerUnit.GetComponent<InitUnit>().canAttack = true;
                playerUnit.GetComponent<InitUnit>().enemy = tmpUnit;

                tmpUnit.GetComponent<InitUnit>().canAttack = true;
                tmpUnit.GetComponent<InitUnit>().enemy = playerUnit;
            } else {
                //Debug.Log("tmpUnit is lost");
                playerUnit.GetComponent<InitUnit>().canAttack = false;
                playerUnit.GetComponent<InitUnit>().enemy = null;
            }
        } else {
            //Debug.Log("there is no player");
        }
        
    }

    public void LetUnitsFight(bool isTheyCan) {
        if (bothTypeUnitsHere == true) {
            Debug.Log("Starting to fight...");
            if (isTheyCan = true) {
                playerUnit.GetComponent<InitUnit>().canAttack = true;
                playerUnit.GetComponent<InitUnit>().enemy = enemyUnit;
            } else {
                enemyUnit.GetComponent<InitUnit>().canAttack = true;
                enemyUnit.GetComponent<InitUnit>().enemy = playerUnit;
            }
        }
    }*/
}
