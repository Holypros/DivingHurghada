using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureScript : MonoBehaviour
{
    public static CreatureScript Tinstance;
    [HideInInspector]
    public GameObject creature;
    [HideInInspector]
    public bool IsTriggerd = false;
    private void Awake()
    {

        if (Tinstance == null)
        {
            Tinstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("creature"))
        {
            IsTriggerd = true;
            creature = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("creature"))
        {
            IsTriggerd = false;

        }
    }

}
