using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] public HealthSystem healthSystem;
    [SerializeField] public GameObject bar;

    private RectTransform rectTransform;
    
    private void Awake() {
        rectTransform = GetComponent<RectTransform>();

        Setup(healthSystem);
    }

    public void Setup(HealthSystem healthSystem) {
            this.healthSystem = healthSystem;
    }

    private void Update() {
        bar.GetComponent<RectTransform>().localScale = new Vector3(healthSystem.GetHealthPercent(),1,1);
    }
}
