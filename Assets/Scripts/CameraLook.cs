using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

[RequireComponent(typeof(CinemachineFreeLook))]

public class CameraLook : MonoBehaviour
{
    [SerializeField] private float lookSpeed = 1.0f;
    [SerializeField] private Transform playerBody;
    [SerializeField] Image image;

    private CinemachineFreeLook cinemachine;
    private Player playerInput;

    public Collider waterCollider;

    float maxY = 28f;



    private void Awake()
    {
        playerInput = new Player();
        cinemachine = GetComponent<CinemachineFreeLook>();

    }
    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    private void Start()
    {
        image.gameObject.SetActive(false);
        
        
    }

    Vector2 oldDelta;
    private void Update()
    {
        Vector2 delta = playerInput.PlayerMain.Look.ReadValue<Vector2>();


        if (oldDelta.x != delta.x)
        {
            cinemachine.m_XAxis.Value += delta.x * 125 * lookSpeed * Time.deltaTime;
        }
        cinemachine.m_YAxis.Value = 0.37f;

        //if (oldDelta.y != delta.y)
        //{
        //    cinemachine.m_YAxis.Value -= delta.y * lookSpeed * Time.deltaTime;
        //}



        if (playerBody.transform.position.y < 26.7f)
        {
            waterCollider.isTrigger = false;
        }
        else
        {
            waterCollider.isTrigger = true;
        }



        oldDelta = delta;


        //if (Camera.main.transform.position.y <= maxY)
        //{
        //    image.gameObject.SetActive(true);
        //}
        //else
        //{
        //    image.gameObject.SetActive(false);
        //}





    }



}
