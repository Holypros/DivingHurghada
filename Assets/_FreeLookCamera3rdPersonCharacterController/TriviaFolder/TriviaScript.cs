using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriviaScript : MonoBehaviour
{
    // Start is called before the first frame update
   
    // Start is called before the first frame update
    bool Triviabuttonclicked = false;
    int counter = 0;
    int find = 0;
    void Start()
    {
        UiManager.UiInstance.TriviaButton.gameObject.SetActive(false);
        //UiManager.UiInstance.infoText.gameObject.SetActive(false);
        UiManager.UiInstance.Triviapanel.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ButterFlyFish"))
        {
            UiManager.UiInstance.TriviaButton.gameObject.SetActive(true);
            find = 1;
        }
        else if (other.gameObject.CompareTag("ClownRed"))
        {
            UiManager.UiInstance.TriviaButton.gameObject.SetActive(true);
            find = 2;
        }
        else if (other.gameObject.CompareTag("ClownOrange"))
        {
            UiManager.UiInstance.TriviaButton.gameObject.SetActive(true);
            find = 3;
        }
        else
        {
            find = 0;
        }
       
    }
    
    private void OnTriggerExit(Collider other)
    {
        UiManager.UiInstance.TriviaButton.gameObject.SetActive(false);
    }

    public void triviabutton()
    {
        Triviabuttonclicked = true;
        counter++;
        if (counter == 1)
        {
            UiManager.UiInstance.Triviapanel.gameObject.SetActive(true);
            if (find == 1) {
                UiManager.UiInstance.TriviaText.text = ("Eclipse or Bennett’s Butterflyfish, This is a peaceful fish that will do well with non - aggressive tankmates, grows to about 6 inches in length 15.24cm.they mainly eat coral polyps.");
            }
            else if (find == 2)
            {
                UiManager.UiInstance.TriviaText.text = ("Maroon clownfish,Lightning maroon.temperament: Aggressive,especially when paired and spawning, Max Size:~6 inches for a large female, about half that for males,In the wild they mainly eat zooplankton.");
            } 
            else if (find == 3)
            {
                UiManager.UiInstance.TriviaText.text = ("Ocellaris clownfisht: PeacefulMax Size: 7.62cm, In the wild they mainly eat zooplankton.");
            }
           
        }
        //UiManager.UiInstance.infoText.gameObject.SetActive(false);
        if (counter == 2)
        {
            UiManager.UiInstance.TriviaButton.gameObject.SetActive(false);
            UiManager.UiInstance.Triviapanel.gameObject.SetActive(false);
            counter = 0;
        }

    }

}


