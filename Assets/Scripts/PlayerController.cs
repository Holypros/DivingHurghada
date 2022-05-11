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

    Transform playerTransform;
    private Transform cameraMain;

    int y = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = transform;
        cameraMain = Camera.main.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandlePlayerMovement(y);
    }

    void HandlePlayerMovement(int y)
    {
        if (y == 1 && playerTransform.position.y >= maxY) {
            y = 0;
        }

        Vector3 targrtVelocity = new Vector3(joystick.Horizontal, y * 0.5f, joystick.Vertical);
        targrtVelocity = playerTransform.TransformDirection(targrtVelocity);
        targrtVelocity *= speed;

        Vector3 velocity = rb.velocity;
        Vector3 velocityChange = targrtVelocity - velocity;
        velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocity, maxVelocity);
        velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocity, maxVelocity);
        velocityChange.y = Mathf.Clamp(velocityChange.y, -maxVelocity, maxVelocity);

        rb.AddForce(velocityChange, ForceMode.VelocityChange);
    }

    public void IsButtonPressed(int value) {
        y = value;
    }
}
