using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputManager : MonoBehaviour
{


    private static InputManager _instance;
    public static InputManager instance {
        get { return _instance; }
            
            }
    [SerializeField]
    Movement movement;
    [SerializeField]
    MouseLook mouseLook;
    //public OpenDoorTrigger openDoorTrigger;
    public bool Jump_Input;
    public bool Interact_Input;

    PlayerControls controls;
    PlayerControls.GroundMovementActions groundMovement;

    public Vector2  horizontalInput;
    public Vector2 mounseInput;

    private void Awake()
    {
        //if (_instance != null && _instance != this)
        //{
        //    Destroy(this.gameObject);
        //}
        //else
        //{
        //    _instance = this;
        //}
        controls = new PlayerControls();
        groundMovement = controls.GroundMovement;


        //ctx is the value so if something is a button it doesnt need context since their is no value to read
        //these are event lambadas if they cause problems switch later
        groundMovement.HorizontalMovement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();
        //groundMovement.HorizontalMovement.performed += ctx => mounseInput = ctx.ReadValue<Vector2>();
        groundMovement.Crouch.performed += _ => movement.OnCrouch();
        groundMovement.Crouch.canceled += _ => movement.crouch = false;
        groundMovement.Jump.performed += _ => Jump_Input = true;
        //groundMovement.Interact.performed += _ => openDoorTrigger.UseDoor();
        groundMovement.MouseX.performed += ctx => mounseInput.x = ctx.ReadValue<float>();
        groundMovement.MouseY.performed += ctx => mounseInput.y = ctx.ReadValue<float>();
        groundMovement.Sprint.performed += _ => movement.OnSprint();
        groundMovement.Sprint.canceled += _ => movement.sprint = false;
        groundMovement.Interact.performed += _ => Interact_Input = true;
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
        HandleJumpingInput();
        HandleInteractionInput();
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
    private void HandleInteractionInput()
    {
        if (Interact_Input)
        {
            if (!movement.canInteract)
            {
                Interact_Input = false;
            }
        }

    }

}



