using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DepthCalc : MonoBehaviour
{
    [SerializeField] Image bar;
    [SerializeField] TextMeshProUGUI depthTxt;
    [SerializeField] float maxY = 6.8f;
    [SerializeField] float minY = -20f;
    [SerializeField] float playerLength = 2f;

    Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        bar.fillAmount = (playerTransform.position.y - playerLength) / (maxY - minY);
        depthTxt.text = (int) ((maxY - minY) - playerTransform.position.y) + " m";
    }
}
