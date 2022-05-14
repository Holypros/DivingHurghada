using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DepthCalc : MonoBehaviour
{


    Transform playerTransform;
    float size;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = transform;
        size = UiManager.UiInstance.DmaxY - UiManager.UiInstance.DminY;
    }

    // Update is called once per frame
    void Update()
    {
        UiManager.UiInstance.Dbar.fillAmount = (size - (UiManager.UiInstance.DmaxY - playerTransform.position.y)) / size;
        UiManager.UiInstance.depthTxt.text = (int)(UiManager.UiInstance.DmaxY - playerTransform.position.y) + " m";
    }
}
