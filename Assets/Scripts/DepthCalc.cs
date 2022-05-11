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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bar.fillAmount = (transform.position.y - playerLength) / (maxY - minY);
        depthTxt.text = (int) ((maxY - minY) - transform.position.y) + " m";
    }
}
