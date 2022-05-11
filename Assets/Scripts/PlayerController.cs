using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] FixedJoystick joystick;
    [SerializeField] Rigidbody rb;

    [SerializeField] float speed = 5;
    [SerializeField] float maxVelocity = 20;
    [SerializeField] float maxY = 7.5f;

    //public Vector3 velocity_reference;
    public float velocity_reference_x;
    public float velocity_reference_y;
    public float velocity_reference_z;

    private Transform cameraMain;

    int y = 0;
    // Start is called before the first frame update
    void Start()
    {
        cameraMain = Camera.main.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandlePlayerMovement(y);
    }

    void HandlePlayerMovement(int y)
    {
        if (y == 1 && transform.position.y >= maxY) {
            y = 0;
        }

        Vector3 targrtVelocity = new Vector3(joystick.Horizontal, y * 0.5f, joystick.Vertical);
        targrtVelocity = transform.TransformDirection(targrtVelocity);
        targrtVelocity *= speed;

        Vector3 velocity = rb.velocity;
        Vector3 velocityChange = targrtVelocity - velocity;
        velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocity, maxVelocity);
        velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocity, maxVelocity);
        velocityChange.y = Mathf.Clamp(velocityChange.y, -maxVelocity, maxVelocity);

        rb.AddForce(velocityChange, ForceMode.VelocityChange);

        //velocity_reference = velocityChange;
        velocity_reference_x = rb.velocity.x;
        velocity_reference_y = rb.velocity.y;
        velocity_reference_z = rb.velocity.z;
    }

    public void IsButtonPressed(int value) {
        y = value;
    }
}
