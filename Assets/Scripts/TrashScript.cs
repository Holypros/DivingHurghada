using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashScript : MonoBehaviour
{
    // Start is called before the first frame update 
    public static TrashScript Tinstance;
    [HideInInspector]
    public GameObject trash;
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
    void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("trash"))
        {
            IsTriggerd = true;
            trash = other.gameObject;

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("trash"))
        {
            IsTriggerd = false;

        }
    }
    // Update is called once per frame

}
