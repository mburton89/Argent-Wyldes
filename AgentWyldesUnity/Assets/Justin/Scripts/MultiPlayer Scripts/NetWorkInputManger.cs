using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class NetWorkInputManger : NetworkBehaviour

{


    [SerializeField]
    CanAttackIsLeshen canAttackIsLeshen;

    [SerializeField]
    Character character;
    [SerializeField]
    NetworkMovement movement;
    [SerializeField]
    NetworkMouseLook mouseLook;
    public bool Jump_Input;
    public bool Attack_Input;


    PlayerControls controls;
    PlayerControls.GroundMovementActions groundMovement;

    public Vector2 horizontalInput;
    Vector2 mounseInput;

    private void Awake()
    {
        controls = new PlayerControls();
        groundMovement = controls.GroundMovement;


        //ctx is the value so if something is a button it doesnt need context since their is no value to read
        //these are event lambadas if they cause problems switch later
        groundMovement.HorizontalMovement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();
        groundMovement.Crouch.performed += _ => movement.OnCrouch();
        groundMovement.Crouch.canceled += _ => movement.crouch = false;
        groundMovement.Jump.performed += _ => Jump_Input = true;
        groundMovement.Sprint.performed += _ => movement.OnSprint();
        groundMovement.Sprint.canceled += _ => movement.sprint = false;
        groundMovement.MouseX.performed += ctx => mounseInput.x = ctx.ReadValue<float>();
        groundMovement.MouseY.performed += ctx => mounseInput.y = ctx.ReadValue<float>();
        if (canAttackIsLeshen != null)
        {
            groundMovement.Attack.performed += _ => Attack_Input = true;
        }  
      
    }


    private void OnEnable()
    {
        controls.Enable();
    }


    private void OnDisable()
    {
        controls.Disable();
        groundMovement.Crouch.performed -= _ => movement.OnCrouch();
        groundMovement.Crouch.canceled -= _ => movement.crouch = false;
        groundMovement.Sprint.performed -= _ => movement.OnSprint();
        groundMovement.Sprint.canceled -= _ => movement.sprint = false;


    }

    private void Update()
    {
        if (!IsOwner)
        {
            return;
        }
        HandleAttackInput();
        HandleJumpingInput();
        movement.ReceieveInput(horizontalInput);
        mouseLook.ReceieveInput(mounseInput);
    }


    private void HandleJumpingInput()
    {

        if (Jump_Input)
        {
            Jump_Input = false;
            movement.HandleJump();
        }






    }
    private void HandleAttackInput()
    {

        if (Attack_Input)
        {
            Attack_Input = false;
            movement.HandleAtack();
        }
    }

}




