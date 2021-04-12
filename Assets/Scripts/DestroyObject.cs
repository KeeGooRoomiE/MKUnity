using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] public GameObject go;

    public void DestroyGameObject() {
        Destroy(go);
    }
}
