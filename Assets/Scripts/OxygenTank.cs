using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OxygenTank : MonoBehaviour
{
    
    [SerializeField] float oxygenLossRate = 0.03f;
    [SerializeField] float oxygenGainRate = 0.05f;

    Transform playerTransform;
    UiManager instanceUI;
    float maxY;

    private void Start()
    {
        playerTransform = transform;
        maxY = GameManager.Instance.GetMaxY();
        instanceUI = UiManager.UiInstance;
    }
    void Update()
    {
        if (playerTransform.position.y <= maxY)
        {
            if (instanceUI.GetOxygenAmount() > 0)
            {
                instanceUI.SetOxygenAmount(instanceUI.GetOxygenAmount() - (oxygenLossRate * Time.deltaTime * (maxY - playerTransform.position.y)));
               
            }
            else
            {
                Time.timeScale = 0;
                instanceUI.ShowGameOverText();
            }
        }
        else 
        {
            instanceUI.SetOxygenAmount(instanceUI.GetOxygenAmount() + oxygenGainRate * Time.deltaTime);
            
        }
    }
}
