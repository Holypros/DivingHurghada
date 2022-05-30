using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OxygenTank : MonoBehaviour
{

    //[SerializeField] float oxygenLossRate = 0.0003f;
    [SerializeField] float oxygenGainRate = 0.05f;

    Transform playerTransform;
   // UiManager instanceUI;
    float maxY;

    private void Start()
    {
        playerTransform = transform;
        maxY = GameManager.Instance.GetMaxY();
       // instanceUI = UiManager.UiInstance;
    }
    void Update()
    {
        if (playerTransform.position.y <= maxY)
        {
            if (UiManager.UiInstance.GetOxygenAmount() > 0)
            {
                UiManager.UiInstance.SetOxygenAmount(UiManager.UiInstance.GetOxygenAmount() - (GameManager.Instance.GetOxygenTank() * 0.0001f * Time.deltaTime * (maxY - playerTransform.position.y)));

            }
            else
            {              
                UiManager.UiInstance.ShowGameOverText();
            }
        }
        else
        {
            UiManager.UiInstance.SetOxygenAmount(UiManager.UiInstance.GetOxygenAmount() + oxygenGainRate * Time.deltaTime);

        }
    }


}
