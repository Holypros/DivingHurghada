using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DepthCalc : MonoBehaviour
{
    Transform playerTransform;
    UiManager instanceUI;

    float size;
    float maxY = 27.2f;
    float minY = -60f;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = transform;
        instanceUI = UiManager.UiInstance;

        maxY = GameManager.Instance.GetMaxY();
        minY = GameManager.Instance.GetMinY();

        size = maxY - minY;
    }

    // Update is called once per frame
    void Update()
    {
        instanceUI.SetDepthAmount((size - (maxY - playerTransform.position.y)) / size);
        instanceUI.SetDepthText((int)(maxY - playerTransform.position.y));
    }
}
