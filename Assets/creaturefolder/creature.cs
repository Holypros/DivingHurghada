using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;

public class creature : MonoBehaviour
{
    // Start is called before the first frame update 
    public static creature CreatureInstance;
    private void Awake()
    {
        if (CreatureInstance == null)
        {
            CreatureInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public PathCreator Cpath;
     public GameObject player;
    //public PathCreator refScript;
    //PathFollower
     [HideInInspector]
    public bool enabledc=false;
     

    void Start()
    {
        //    PathCreator pathc = new PathCreator();
        //    PathCreator.

        //refScript = GetComponent<PathCreator>();
        //refScript.enabled = false;
        UiManager.UiInstance.catchButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

            if (UiManager.UiInstance.clicked ==2)

            {
                    
                    UiManager.UiInstance.congrats.gameObject.transform.localPosition = CreatureScript.Tinstance.creature.transform.position;
                    UiManager.UiInstance.congrats.gameObject.SetActive(true);
                    Destroy(CreatureScript.Tinstance.creature.gameObject);
                    UiManager.UiInstance.caughtCreature = true;
                    UiManager.UiInstance.catchButton.gameObject.SetActive(false);
                    CreatureScript.Tinstance.IsTriggerd = false;
                    UiManager.UiInstance.nextLevel.gameObject.SetActive(true);
                
            }

         
           
        


        
    }
}
