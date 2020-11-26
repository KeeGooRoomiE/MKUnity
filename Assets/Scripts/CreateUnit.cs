using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateUnit : MonoBehaviour
{
    [SerializeField] public GameObject unit;
    [SerializeField] public Transform parent;

    private Vector3 mousePos;

    public void UnitCreating() {
        
         mousePos = Input.mousePosition;

        if (unit != null) {
            if (parent != null) {
                GameObject tmpUnit = Instantiate(unit,parent);
                tmpUnit.SetActive(true);
                tmpUnit.transform.position = new Vector3(mousePos.x, mousePos.y, 10);
                
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
