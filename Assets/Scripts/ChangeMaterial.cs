using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public Material[] material;
    Material setMaterial;
    Renderer rend;
    //[SerializeField] GameObject player;
    void Start()
    {
        //GameObject prefab = Resources.Load<GameObject>("Animations/X Bot/Materials/3_asdf1_Beta_HighLimbsGeoSG2 1.mat"); // Path WITHOUT "Resources/"
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        
        rend.sharedMaterial = material[0]; 
     
        //prefab = material[0];
    }

    // Update is called once per frame
    void Update()
    {
        rend.sharedMaterial = material[2];
    }

    public void BrownMaterial()
    {
        rend.sharedMaterial = material[0];
        setMaterial = rend.material;
    }

    public void RedMaterial()
    {
        rend.sharedMaterial = material[1];
        setMaterial = rend.material;
    }

    public void BlueMaterial()
    {
        rend.sharedMaterial = material[2];
        setMaterial = rend.material;
    }

}
