using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCountdown : MonoBehaviour
{
    public Button Button;
    public float TimeToAwake;
    public float curTime;
    public float period = 3.0f;
    public Text textComp;
    public bool isTimeSet;

    private void Start() {
    //check triggers
    Button.interactable = false;
    //TimeToAwake = Time.time + period;
    isTimeSet = false;
    }

    void Update() {
       curTime = Time.time;

        if (isTimeSet == false) {
            isTimeSet = true;
            TimeToAwake = curTime + 3.0f;
        }


        if (Time.time > TimeToAwake ) {
            Button.interactable = true;
            //TimeToAwake += period;
        }

        if (Button.interactable == true) {
            textComp.text = "";
            
        } else {
            textComp.text = (-1*((int)Time.time - (int)TimeToAwake)).ToString();
        }
    }

    public void ResetTimeSet() {
        isTimeSet = false;
        Button.interactable = false;
    }
}
