using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class InitUnit : MonoBehaviour, IEndDragHandler
{
    //[SerializeField] public GameObject HealthBar;               //healthbar index
    [SerializeField] public GameObject target;                  //uses to index enemy
    [SerializeField] public int currentLoc;                     //saves location number to compare 
    [SerializeField] public int AttackValue;                    //current unit attack value
    [SerializeField] public bool canAttack;                     //bool variable for ability to attack
    [SerializeField] public bool commitAttack;                  //bool variable for commencing attack
    //public int nearestDist;
    //public bool canFindEnemy;

    private void Awake() {
        currentLoc = 0;
        //canFindEnemy = false;
        commitAttack = true;
        AttackValue = 2;
    }

    IEnumerator PlayerAtkDelay(float time) {
        yield return new WaitForSeconds(time);
        commitAttack = true;
    }


    void Update() {
        //checkouts unit and enemy locations
        /*if (target != null) {
            if (currentLoc == target.GetComponent<InitUnit>().currentLoc) {
                canAttack = true;
            } else {
                canAttack = false;
            }
        } else {
            canAttack = false;
        }*/

        //attacking behaviour
        if (target != null) {
            if (canAttack == true) {
                if (commitAttack == true) {
                    target.GetComponent<HealthSystem>().Damage(AttackValue);
                    StartCoroutine(PlayerAtkDelay(1.1f));
                    commitAttack = false;
                }
            }
        }

        //if (canAttack == true) {
            /*
            //close that part is enemy is not found
            if (target == null) {
                canAttack = false;
            } else {
                canAttack = true;
            }
            */

            //permits attacking of enemy
            /*if (commitAttack == true) {
                HealthBar.SetActive(true);
                target.GetComponent<HealthSystem>().Damage(2);
                StartCoroutine(Delay(1.0f));
                commitAttack = false;
            } else {
                HealthBar.SetActive(false);
            }
        } else {
            HealthBar.SetActive(false);
        }*/
    }

    //triggers with location
    private void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.tag == "LocationTrigger") {
            currentLoc = other.GetComponent<LocationTriggerCollider>().locationNumber;
            other.GetComponent<LocationTriggerCollider>().playerUnit = this.gameObject;

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
