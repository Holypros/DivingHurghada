using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScriptController : MonoBehaviour
{
    PlayerController PlayerReference;
    Animator animator;
    [SerializeField] GameObject player_velocity;
    //[SerializeField] GameObject player_velocity_x;
    //[SerializeField] GameObject player_velocity_y;
    //[SerializeField] GameObject player_velocity_z;

    // Start is called before the first frame update
    void Start()
    {
        PlayerReference = player_velocity.GetComponent<PlayerController>();
        //PlayerReference = player_velocity_x.GetComponent<PlayerController>();
        //PlayerReference = player_velocity_y.GetComponent<PlayerController>();
        //PlayerReference = player_velocity_z.GetComponent<PlayerController>();

        animator = GetComponent<Animator>();
        Debug.Log(animator);
    }

    // Update is called once per frame
    void Update()
    {
        if ( (PlayerReference.velocity_reference_x != 0.0f) || (PlayerReference.velocity_reference_y != 0.0f) || (PlayerReference.velocity_reference_z != 0.0f) )
        {
            animator.SetBool("IsSwimming", true);
        }
        else
        {
            animator.SetBool("IsSwimming", false);
        }
    }

    private Vector3 Vector3(int v1, int v2, int v3)
    {
        throw new NotImplementedException();
    }
}
