using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCountdown : MonoBehaviour
{
    public Button Button;
    public float TimeToAwake;
    public float period = 3.0f;
    public Text textComp;

    private void Start() {
    //check triggers
    Button.interactable = false;
    TimeToAwake = Time.time + 3.0f;
    }

    void Update() {
       
        if (Time.time > TimeToAwake ) {
            Button.interactable = true;
            TimeToAwake += period;
        }

        if (Button.interactable == true) {
            textComp.text = "";
        } else {
            textComp.text = (-1*((int)Time.time - (int)TimeToAwake)).ToString();
        }
    }
}
