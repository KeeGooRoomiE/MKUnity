using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LocGrowthSwitcher : MonoBehaviour
{
    [SerializeField] public Sprite[] sprites;
    [SerializeField] public Image sprite;
    [SerializeField] public LocationBehaviour locInfo;

    // Update is called once per frame
    void Update()
    {
         sprite.sprite = sprites[locInfo.locGrowth/10];
    }
}
