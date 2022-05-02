using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class trashscript : MonoBehaviour
{


   
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Button button;
  
   
    int speed = 5;
    bool istriggered = false;
    bool isclicked = false;
    float destroyTimer = 0; 
  

    // Start is called before the first frame update
    void Start()
    {
        text.gameObject.SetActive(false);
       ;
    }

    // Update is called once per frame
    void Update()
    {
        textfun();


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            button.gameObject.SetActive(true);
          istriggered = true;
        }
    }

    public void ButtonClick()
    {
        if (istriggered)
        {
            button.gameObject.SetActive(false);
            isclicked = true;
        }

    }
    void textfun()
    {
        if (isclicked == true)
        {
            destroyTimer += Time.deltaTime;
            Debug.Log(Time.deltaTime);
            text.gameObject.SetActive(true);
            text.transform.position += new Vector3(0, 0.2f, 0) * speed * Time.deltaTime;
            if (destroyTimer >= 1.0f)
            {
               Destroy(this.gameObject);
                isclicked = false;
            }
          
        }
        
    }
}
