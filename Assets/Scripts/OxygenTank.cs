using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OxygenTank : MonoBehaviour
{
    //[SerializeField] Image bar;
    //[SerializeField] GameObject gameOvetTxt;
    //[SerializeField] float oxygenLossRate = 0.03f;
    //[SerializeField] float oxygenGainRate = 0.05f;
    //[SerializeField] float maxY;

    Transform playerTransform;
    private void Start()
    {
        playerTransform = transform;
    }
    void Update()
    {
        if (playerTransform.position.y <= UiManager.UiInstance.maxY)
        {
            if (UiManager.UiInstance.bar.fillAmount > 0)
                UiManager.UiInstance.bar.fillAmount -= UiManager.UiInstance.oxygenLossRate * Time.deltaTime * (UiManager.UiInstance.maxY - playerTransform.position.y);
            else
            {
                Time.timeScale = 0;
                UiManager.UiInstance.gameOvetTxt.SetActive(true);
            }
        }
        else 
        {
            UiManager.UiInstance.bar.fillAmount += UiManager.UiInstance.oxygenGainRate * Time.deltaTime;
        }
    }
}
