using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OxygenTank : MonoBehaviour
{
    [SerializeField] Image bar;
    [SerializeField] GameObject gameOvetTxt;
    [SerializeField] float oxygenLossRate = 0.03f;
    [SerializeField] float oxygenGainRate = 0.05f;
    [SerializeField] float maxY = 6.8f;

    void Update()
    {
        if (transform.position.y <= maxY)
        {
            if (bar.fillAmount > 0)
                bar.fillAmount -= oxygenLossRate * Time.deltaTime;
            else
            {
                Time.timeScale = 0;
                gameOvetTxt.SetActive(true);
            }
        }
        else 
        {
            bar.fillAmount += oxygenGainRate * Time.deltaTime;
        }
    }
}
