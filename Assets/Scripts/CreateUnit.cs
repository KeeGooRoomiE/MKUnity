using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateUnit : MonoBehaviour
{
    [SerializeField] public GameObject unit;
    [SerializeField] public Transform parent;
    [SerializeField] public Transform place;

    private Vector3 mousePos;

    public void UnitCreating() {
        
         mousePos = Input.mousePosition;

        if (unit != null) {
            if (parent != null) {
                GameObject tmpUnit = Instantiate(unit,parent);
                tmpUnit.SetActive(true);
                Debug.Log("Setting positions...");
                tmpUnit.transform.position = place.transform.position;
                Debug.Log("Unit position["+tmpUnit.transform.position+"] Expected["+mousePos.x+","+mousePos.y+","+0f+"]");
                //new Vector3(-495f, 80f, 0);
                
                //Debug.Log("Unit instantiate");
                //Debug.Log("Unit: " + unit);
            }
            
            //Debug.Log("MousePos.x "+mousePos.x);
            //Debug.Log("MousePos.y "+mousePos.y);
            //Debug.Log("tmpUnit.x "+tmpUnit.transform.position.x);
            //Debug.Log("tmpUnit.y "+tmpUnit.transform.position.y);
        };
    }
}
