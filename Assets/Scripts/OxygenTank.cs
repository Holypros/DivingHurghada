using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OxygenTank : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] float oxygenLossRate = 0.03f;
    [SerializeField] float oxygenGainRate = 0.05f;

    Transform playerTransform;
    private void Start()
    {
        image.gameObject.SetActive(false);
        playerTransform = transform;
    }
    void Update()
    {
        if (playerTransform.position.y <= GameManager.Instance.GetMaxY())
        {
            if (UiManager.UiInstance.OxygenBar.fillAmount > 0)
            {
                UiManager.UiInstance.OxygenBar.fillAmount -= oxygenLossRate * Time.deltaTime * (GameManager.Instance.GetMaxY() - playerTransform.position.y);
                image.gameObject.SetActive(true);
            }
            else
            {
                Time.timeScale = 0;
                UiManager.UiInstance.gameOvetTxt.SetActive(true);
            }
        }
        else 
        {
            UiManager.UiInstance.OxygenBar.fillAmount += oxygenGainRate * Time.deltaTime;
            image.gameObject.SetActive(false);
        }
    }
}
