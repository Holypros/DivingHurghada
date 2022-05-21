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

    float maxY = 28.15f;



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


    private void Update()
    {
        Vector2 delta = playerInput.PlayerMain.Look.ReadValue<Vector2>();
        cinemachine.m_XAxis.Value += delta.x * 125 * lookSpeed * Time.deltaTime;
        cinemachine.m_YAxis.Value -= delta.y * lookSpeed * Time.deltaTime;

        if (Camera.main.transform.position.y <= maxY)
        {
            image.gameObject.SetActive(true);
        }
        else
        {
            image.gameObject.SetActive(false);
        }





    }



}
