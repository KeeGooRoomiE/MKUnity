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
    [SerializeField] public LineRenderer sight;

    void Awake() {
        canAttack = true;
        commitAttack = true;
    }

    void Update() {
        if (target != null) {
            Debug.Log("E: found a traget");
            if (canAttack == true) {
                Debug.Log("E: can make attack");
                sight.gameObject.SetActive(true);
                Debug.Log("E: activated line");
                Vector3 sp = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 10);
                
                Vector3 ep = new Vector3(target.transform.position.x, target.transform.position.y, 10);
                Debug.Log("E: positions are set");
                Debug.Log("E: sp"+sp);
                Debug.Log("E: ep"+ep);
                sight.SetVertexCount(2);
                sight.startWidth = 0.1f;
                sight.endWidth = 0.1f;
                sight.useWorldSpace = true;
                sight.SetPosition(0, sp);
                Debug.Log("E: sp position set");
                sight.SetPosition(1, ep);
                Debug.Log("E: ep position set");

                if (commitAttack == true) {
                    target.GetComponent<HealthSystem>().Damage(AttackValue);
                    StartCoroutine(Delay(1.0f));
                    commitAttack = false;
                }
            } else {
                sight.gameObject.SetActive(false);
            }
        } else {
            sight.gameObject.SetActive(false);
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
