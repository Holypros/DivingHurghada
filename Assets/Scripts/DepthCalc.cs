using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DepthCalc : MonoBehaviour
{
    [SerializeField] Image bar;
    [SerializeField] TextMeshProUGUI depthTxt;
    [SerializeField] float maxY;
    [SerializeField] float minY;
    [SerializeField] float playerLength;

    Transform playerTransform;
    float size;
    //float maxY = 27.2f;
    //float minY = -60f;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = transform;
        size = maxY - minY;
    }

    // Update is called once per frame
    void Update()
    {
        bar.fillAmount = (size - (maxY - playerTransform.position.y)) / size;
        depthTxt.text = (int) (maxY - playerTransform.position.y) + " m";
    }
}
