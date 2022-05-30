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
    
    //Vector3 swimmimgspeed;
    //Vector3 swimmingchange;

    //public Vector3 velocity_reference;
    public float velocity_reference_x;
    public float velocity_reference_y;
    public float velocity_reference_z;

    Transform playerTransform;
    [SerializeField]
    private Transform cameraMain;

    int y = 0;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = transform;
        pos = new Vector3(2, 2, 2);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandlePlayerMovement(y);
        if (rb.velocity.magnitude >= pos.magnitude)
        {
            AudioManager.AudioInstance.SwimmingEffect.volume = 1;
            if(!AudioManager.AudioInstance.SwimmingEffect.isPlaying)
            AudioManager.AudioInstance.SwimmingEffect.PlayOneShot(AudioManager.AudioInstance.SwimmimgClip);
                //OneShot(AudioManager.AudioInstance.SwimmimgClip);
        }
        else
        {
            if (AudioManager.AudioInstance.SwimmingEffect.isPlaying)
                AudioManager.AudioInstance.SwimmingEffect.Stop();
        }
       
    }

    void HandlePlayerMovement(int y)
    {
        if (y == 1 && playerTransform.position.y >= maxY) {
            y = 0;
        }

        Vector3 targrtVelocity = new Vector3(joystick.Horizontal, y * 0.5f, joystick.Vertical);

        targrtVelocity = Quaternion.AngleAxis(cameraMain.rotation.eulerAngles.y, Vector3.up) * targrtVelocity;

        targrtVelocity *= speed;

        Vector3 velocity = rb.velocity;
        Vector3 velocityChange = targrtVelocity - velocity;
        velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocity, maxVelocity);
        velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocity, maxVelocity);
        velocityChange.y = Mathf.Clamp(velocityChange.y, -maxVelocity, maxVelocity);

        rb.AddForce(velocityChange, ForceMode.VelocityChange);
        //swimmimgspeed = velocity;
        //swimmingchange = velocityChange;

        //velocity_reference = velocityChange;
        velocity_reference_x = rb.velocity.x;
        velocity_reference_y = rb.velocity.y;
        velocity_reference_z = rb.velocity.z;
    }

    public void IsButtonPressed(int value) {
        y = value;
    }
}
