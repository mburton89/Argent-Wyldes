using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class NetworkMouseLook : NetworkBehaviour
{

    [SerializeField] float sensitivityX = 8f;
    [SerializeField] float sensitivityY = .05f;
    [SerializeField] GameObject playerCamera;
    [SerializeField] Transform playerCameraTransform;
    [SerializeField] float xClamp = 85f;
    float mouseX;
    float mouseY;
    float xRotation = 0;

    private void Awake()
    {
        if (playerCamera == null)
        {
            playerCamera = GameObject.FindGameObjectWithTag("PlayerCamera");

        }
    }


    private void Update()
    {
        if (!IsOwner)
        {
            return;
        }

        transform.Rotate(Vector3.up, mouseX * Time.deltaTime);
        xRotation -= mouseY; //if you use +=  it reverses controls
        xRotation = Mathf.Clamp(xRotation, -xClamp, xClamp); //player cant look behind them
        Vector3 targetRotation = transform.eulerAngles; //get the rotataion of the player
        targetRotation.x = xRotation;
        playerCameraTransform = playerCamera.transform;
        playerCameraTransform.eulerAngles = targetRotation;


    }

    public void ReceieveInput(Vector2 mouseInput)
    {

        mouseX = mouseInput.x * sensitivityX;
        mouseY = mouseInput.y * sensitivityY;

    }



}
