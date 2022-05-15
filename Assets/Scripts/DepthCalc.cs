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
        size = GameManager.Instance.GetMaxY() - GameManager.Instance.GetMinY();
    }

    // Update is called once per frame
    void Update()
    {
        UiManager.UiInstance.DepthBar.fillAmount = (size - (GameManager.Instance.GetMaxY() - playerTransform.position.y)) / size;
        UiManager.UiInstance.DepthTxt.text = (int)(GameManager.Instance.GetMaxY() - playerTransform.position.y) + " m";
    }
}
