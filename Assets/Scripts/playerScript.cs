using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class playerScript : MonoBehaviour
{
    // Start is called before the first frame update 
    [SerializeField] Button button;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] TextMeshProUGUI scoreT;
    
    GameObject trash;
    bool buttonIsCliked = false;
    float textTimer = 0;
    int speed = 50;
    int playerscore = 0;
    void Start()
    {
        button.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
        scoreT.text = ("Score:" + playerscore);
    }

    // Update is called once per frame
    void Update()
    {
        textTimer += Time.deltaTime;
       // Debug.Log(text.gameObject.transform.position);
       // Debug.Log(textTimer); 
        scoreT. text = ("Score:" + playerscore);
        if (buttonIsCliked)
        {
            text.gameObject.SetActive(true);
            text.transform.position += new Vector3(0, 3, 0) * speed * Time.deltaTime;

          //  Debug.Log(playerscore);
        }
      
       
           
     

    }
    private void OnTriggerEnter(Collider other)
    {
        text.gameObject.SetActive(false);
        other.gameObject.CompareTag("trash");
        button.gameObject.SetActive(true);
        trash = other.gameObject;
        text.gameObject.transform.position = trash.gameObject.transform.position;
        buttonIsCliked = false;


    } 

    public void buttonClicked()
    {
        Debug.Log("Button");
        button.gameObject.SetActive(false);
        Destroy(trash.gameObject);
       playerscore += 3;  
      buttonIsCliked = true;

    }

   
}
