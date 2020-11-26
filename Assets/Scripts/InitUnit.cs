using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class InitUnit : MonoBehaviour, IEndDragHandler
{
    public int currentLoc;          //saves location number to compare
    public GameObject enemy;        //uses to inddex enemy 
    public int nearestDist;         //used as value for maximun distance
    public bool canFindEnemy;       //bool variable
    public bool canAttack;         //bool variable
    public int attackValue;
    
    public float nextActionTime = 0.0f;
    public float period = 0.5f;

    // Start is called before the first frame update
    private void Awake() {
        currentLoc = 0;
        canFindEnemy = false;
    }

    void Update() {
        if (canAttack) {
            if (currentLoc != enemy.GetComponent<InitUnit>().currentLoc) {
                //Debug.Log("units locs not compare");
                canAttack = false;
                enemy = null;
            } else {
                //Debug.Log("Units locs"+currentLoc+" and "+enemy.GetComponent<InitUnit>().currentLoc+" are equals");
                if (Time.time > nextActionTime ) {
                    enemy.GetComponent<HealthSystem>().Damage(attackValue);
                    nextActionTime += period;
                }
            } 
        }
    }

    //triggers with location
    private void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.tag == "LocationTrigger") {
            currentLoc = other.GetComponent<LocationTriggerCollider>().locationNumber;
        }
    }

    //trigger end with location
    private void OnTriggerExit2D(Collider2D other) {
        currentLoc = 0;
    }

    //
    public void OnEndDrag(PointerEventData eventData) {
        if (currentLoc != 0) {
            //Debug.Log("currentLoc: " + currentLoc);
        } else {
            //Debug.Log("currentLoc is null");
        }
    }
}
