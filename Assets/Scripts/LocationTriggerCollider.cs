using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationTriggerCollider : MonoBehaviour
{
    [SerializeField] public GameObject location;
    [SerializeField] public int locationNumber;
    [SerializeField] public Transform parent;
    [SerializeField] public GameObject enemyUnit;
    [SerializeField] public int EnemyValue;
    [SerializeField] private int unitCount;
    
    private bool isUnitCreated;
    private GameObject tmpUnit;
    private GameObject playerUnit;
    private RectTransform rectTransform;
    
    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        isUnitCreated = false;
        }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Unit") {
            unitCount += 1;
            playerUnit = other.gameObject;
        }

        //check if available to make an enemy
        if (tmpUnit == null) {
            isUnitCreated = false;
        }

        //create enemy unit
        if (Random.Range(0,100) > EnemyValue) {
            if (!isUnitCreated) {
                tmpUnit = Instantiate(enemyUnit,parent);
                tmpUnit.transform.position = location.transform.position;
                isUnitCreated = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        //Debug.Log("Something is collided!");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Unit") {
            unitCount -= 1;
            playerUnit = null;
        }
    }

    void Update() {

        //check both units to start attack
        if (playerUnit != null) {
            if (tmpUnit != null) {
                playerUnit.GetComponent<InitUnit>().canAttack = true;
                playerUnit.GetComponent<InitUnit>().enemy = tmpUnit;

                tmpUnit.GetComponent<InitUnit>().canAttack = true;
                tmpUnit.GetComponent<InitUnit>().enemy = playerUnit;
            } else {
                Debug.Log("tmpUnit is lost");
                playerUnit.GetComponent<InitUnit>().canAttack = false;
                playerUnit.GetComponent<InitUnit>().enemy = null;
            }
        } else {
            //Debug.Log("there is no player");
        }
    }
}
