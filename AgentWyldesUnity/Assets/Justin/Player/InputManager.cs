using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{



    [SerializeField]
    Movement movement;
    [SerializeField]
    MouseLook mouseLook;


    PlayerControls controls;
    PlayerControls.GroundMovementActions groundMovement;

    Vector2 horizontalInput;
    Vector2 mounseInput;

    private void Awake()
    {
        controls = new PlayerControls();
        groundMovement = controls.GroundMovement;


        //ctx is the value so if something is a button it doesnt need context since their is no value to read
        //these are event lambadas if they cause problems switch later
        groundMovement.HorizontalMovement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();
        groundMovement.Jump.performed += _ => movement.OnJumpPressed();

        groundMovement.MouseX.performed += ctx => mounseInput.x = ctx.ReadValue<float>();
        groundMovement.MouseY.performed += ctx => mounseInput.y = ctx.ReadValue<float>();

    }


    private void OnEnable()
    {
        controls.Enable();
    }


    private void OnDisable()
    {
        controls.Disable(); 



    }

    private void Update()
    {
        movement.ReceieveInput(horizontalInput);
        mouseLook.ReceieveInput(mounseInput);
    }




}



