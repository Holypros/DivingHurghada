using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AnimationScriptController : MonoBehaviour
{
    PlayerController PlayerReference;
    Animator animator;
    [SerializeField] GameObject player_velocity;

    public float speed;
    public float rotationSpeed;

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
       
    }

    // Update is called once per frame
    void Update()
    {
        if ((PlayerReference.velocity_reference_x != 0.0f) || (PlayerReference.velocity_reference_y != 0.0f) || (PlayerReference.velocity_reference_z != 0.0f))
        {
            animator.SetBool("IsSwimming", true);
        }
        else
        {
            animator.SetBool("IsSwimming", false);
        }

        float horizontalInput = PlayerReference.velocity_reference_x;
        float verticalInput = PlayerReference.velocity_reference_z;

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        transform.Rotate(movementDirection * speed * Time.deltaTime, Space.World);

        if ((PlayerReference.velocity_reference_x != 0.0f) && (PlayerReference.velocity_reference_z != 0.0f))
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector2.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

    }

    //private Vector3 Vector3(int v1, int v2, int v3)
    //{
    //    throw new NotImplementedException();
    //}
}
