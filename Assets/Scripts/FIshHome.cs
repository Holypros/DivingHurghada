using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIshHome : MonoBehaviour
{
    // Start is called before the first frame update.
    public static FIshHome FishH;

   

    public bool IsHome =false;
    

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CreatureHome"))
        {
            IsHome = true;
        }

    }
  
}
