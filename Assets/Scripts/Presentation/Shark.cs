using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour
{
    [SerializeField] SkinnedMeshRenderer mesh;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    int x = 0;
    int i = 1;
    bool b = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            b = !b;
            x = 100;
        }
        if (b)
        {
            if (x == 100)
                i = -1;
            else if (x == 0)
                i = 1;

            x += i;
            
        }
        mesh.SetBlendShapeWeight(0, x);
    }
}
