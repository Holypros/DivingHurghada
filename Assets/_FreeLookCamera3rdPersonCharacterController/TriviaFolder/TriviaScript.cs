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
        else if (other.gameObject.CompareTag("Napoleonfish1"))
        {

            UiManager.UiInstance.TriviaButton.gameObject.SetActive(true);
            find = 4;

        }
        else if (other.gameObject.CompareTag("Napoleonfish2"))
        {

            UiManager.UiInstance.TriviaButton.gameObject.SetActive(true);
            find = 5;

        }
        else if (other.gameObject.CompareTag("Shark"))
        {

            UiManager.UiInstance.TriviaButton.gameObject.SetActive(true);
            find = 6;

        }
        
       
    }
    
    //private void OnTriggerExit(Collider other)
    //{
    //    UiManager.UiInstance.TriviaButton.gameObject.SetActive(false);
    //    UiManager.UiInstance.Triviapanel.gameObject.SetActive(false);
    //}

    public void triviabutton()
    {
        
        counter++;
        if (counter == 1)
        {
            Triviabuttonclicked = true;
            UiManager.UiInstance.Triviapanel.gameObject.SetActive(true);
            if (find == 1) {
                UiManager.UiInstance.TriviaText.text = ("Eclipse or Bennett’s Butterflyfish, This is a peaceful fish that will do well with non - aggressive tankmates, grows to about 6 inches in length 6 inches.they mainly eat coral polyps.");
                UiManager.UiInstance.Fish.sprite = UiManager.UiInstance.ButterFlyFish;
            } 
          if (find == 2)
            {
                UiManager.UiInstance.TriviaText.text = ("Maroon clownfish,maroon.temper: Aggressive,especially when paired and spawning, Max Size: 6 inches for a large female, about half that for males,In the wild they mainly eat zooplankton.");
                UiManager.UiInstance.Fish.sprite = UiManager.UiInstance.ClownRed;
            } 
           if (find == 3)
            {
                UiManager.UiInstance.TriviaText.text = ("Ocellaris clownfisht: PeacefulMax Size: 3 inches, In the wild they mainly eat zooplankton.");
                UiManager.UiInstance.Fish.sprite = UiManager.UiInstance.ClownOrange;
            }
          if (find == 4)
            {
                UiManager.UiInstance.TriviaText.text = ("Napoleon fish: Peaceful but In some areas they are very curious, Size:72 inches , they roam through coral reefs always in search of prey to eat, and prefer fish with hard shell.");
                UiManager.UiInstance.Fish.sprite = UiManager.UiInstance.Napoleonfish1;
            }
             if (find == 5)
            {
                UiManager.UiInstance.TriviaText.text = ("Napoleon fish: Peaceful but In some areas they are very curious, Size: 72 inches , they roam through coral reefs always in search of prey to eat, and prefer fish with hard shell.");
                UiManager.UiInstance.Fish.sprite = UiManager.UiInstance.Napoleonfish2;
            } 
             if (find == 6)
            {
                UiManager.UiInstance.TriviaText.text = ("hammerhead shark: Predatory, Size– 5.5 meters - It feeds on bony fish and also the tiger shark which is one of its favorite prey, this shark also eats crustaceans and mollusks.");
                UiManager.UiInstance.Fish.sprite = UiManager.UiInstance.Shark;
            } 
            
        }
        if (counter == 1)
        {
            Triviabuttonclicked = false;
        }
        
        //UiManager.UiInstance.infoText.gameObject.SetActive(false);
        if ( counter == 2&& Triviabuttonclicked == false)
        {
            UiManager.UiInstance.TriviaButton.gameObject.SetActive(false);
            UiManager.UiInstance.Triviapanel.gameObject.SetActive(false);
            counter = 0;
        }

    }

}


