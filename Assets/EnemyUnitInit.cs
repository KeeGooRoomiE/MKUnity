using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyUnitInit : MonoBehaviour
{
    [SerializeField] public GameObject target;
    [SerializeField] public GameObject location;
    [SerializeField] public int currentLoc;
    [SerializeField] public int AttackValue;
    [SerializeField] public bool canAttack;
    [SerializeField] public bool commitAttack;

    void Awake() {
        canAttack = true;
        commitAttack = true;
    }

    void Update() {
        if (target != null) {
            if (canAttack == true) {
                if (commitAttack == true) {
                    target.GetComponent<HealthSystem>().Damage(AttackValue);
                    StartCoroutine(Delay(1.0f));
                    commitAttack = false;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "LocationTrigger") {
            currentLoc = other.GetComponent<LocationTriggerCollider>().locationNumber;
            location = other.gameObject;
            location.GetComponent<LocationTriggerCollider>().ActiveEnemyUnit = true;
            location.GetComponent<LocationTriggerCollider>().enemyUnit = this.gameObject;
        }
    }

    IEnumerator Delay(float time) {
        yield return new WaitForSeconds(time);
        commitAttack = true;
    }
}
