using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField] CharacterController controller;
    [SerializeField] PlayerControls inputActions;
   public InputManager inputManager;
    [SerializeField] PlayerInput playerInput;
    [SerializeField] float speed = 11f;
    [SerializeField] float crouchspeed = 1.1f;
    [SerializeField] float sprintspeed = 20f;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] LayerMask groundmask;
    [SerializeField] float jumpheight = 3.5f;
    [SerializeField] float animationSmoothTime = 0.1f;
    [SerializeField] Transform followTarget;
    private CinemachineVirtualCamera _cinemachineVirtualCamera;


    private Animator animator;
    int moveXParameterId;
    private int jumpParameter;
    private InputAction moveaction;
    private InputAction jumpaction;
    private InputAction crouchaction;
    int moveZParameterId;
    int jumpAnimation;
    int crouchAnimation;
    bool jump;
    public bool crouch;
    bool isgrounded;
    int sprintAnimation;
    public bool sprint;
    bool isJumping;
    private InputAction sprintaction; 
    Vector2 currentAnimationnBlendVector;
    Vector2 animationVelocity;
    Vector3 verticalVelocity = Vector3.zero;
    Vector2 horizontalInput;
    private float animationPlayTransition = 0.15f;
    private int jumpParameter1;
    public bool canInteract;
    private void awake()
    {

        //if (_mainCamera == null)
        //{
        //    _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        //}
        if (_cinemachineVirtualCamera == null)
        {
            _cinemachineVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        }
        _cinemachineVirtualCamera.Follow = followTarget;
      
        
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
        //inputManager = GetComponent<InputManager>();
        inputManager = GetComponent<InputManager>();
        jumpAnimation = Animator.StringToHash("Jump");
        crouchAnimation = Animator.StringToHash("Crouch");
        sprintaction = playerInput.actions["Sprint"];
        moveaction = playerInput.actions["Horizontal Movement"];
        jumpaction = playerInput.actions["Jump"];
        crouchaction = playerInput.actions["Crouch"];
        sprintAnimation = Animator.StringToHash("isSprinting");
        //sprintaction = playerInput.actions["Sprint"];
        moveXParameterId = Animator.StringToHash("MoveX");
        jumpParameter = Animator.StringToHash("isJumping");
        jumpParameter1 = Animator.StringToHash("isJumping1");

        moveZParameterId = Animator.StringToHash("MoveZ");
    }
    private void Update()
    {


        if (isJumping)
        {
            return;
        }
        isgrounded = controller.isGrounded;
        if (isgrounded)
        {
            print("isgrounded");
            
        }
        else
        {
            print("is not grounded");
        }
        if (isgrounded)
        {
            verticalVelocity.y = 0;
        }
        horizontalInput = moveaction.ReadValue<Vector2>();

        currentAnimationnBlendVector = Vector2.SmoothDamp(currentAnimationnBlendVector, horizontalInput, ref animationVelocity, animationSmoothTime);

        //Vector3 horizontalVelocity = new Vector3(currentAnimationnBlendVector.x, 0, currentAnimationnBlendVector.y);
        ////if (crouch)
        //{
        //    horizontalVelocity = (transform.right.normalized * horizontalVelocity.x + transform.forward.normalized * horizontalVelocity.z) * crouchspeed;
        //}
        //else
        //{
        //    horizontalVelocity = (transform.right.normalized * horizontalVelocity.x + transform.forward.normalized * horizontalVelocity.z) * speed;

        //}
        //if (isJumping)
        //{
        //    return;
        //}
        //else
        //{
        //    controller.Move(horizontalVelocity * Time.deltaTime);
        //    animator.SetFloat(moveXParameterId, currentAnimationnBlendVector.x);
        //    animator.SetFloat(moveZParameterId, currentAnimationnBlendVector.y);
        //}
        Vector3 horizontalVelocity = new Vector3(currentAnimationnBlendVector.x, 0, currentAnimationnBlendVector.y);
        if (crouch && !sprint)
        {
            horizontalVelocity = (transform.right.normalized * horizontalVelocity.x + transform.forward.normalized * horizontalVelocity.z) * crouchspeed;
        }
        else if (!crouch && sprint)
        {
            horizontalVelocity = (transform.right.normalized * horizontalVelocity.x + transform.forward.normalized * horizontalVelocity.z) * sprintspeed;
        }
        else
        {
            horizontalVelocity = (transform.right.normalized * horizontalVelocity.x + transform.forward.normalized * horizontalVelocity.z) * speed;

        }
        if (isJumping)
        {
            return;
        }
        else
        {
            controller.Move(horizontalVelocity * Time.deltaTime);
            animator.SetFloat(moveXParameterId, currentAnimationnBlendVector.x);
            animator.SetFloat(moveZParameterId, currentAnimationnBlendVector.y);
        }


        //jump height equation: v = sqrt(-2 * jumpheight * gravity
        //if (jump)
        //{
        //   //isJumping = animator.GetBool(jumpParameter);

        //    if (isgrounded && jumpaction.triggered)
        //    {
        //        //animator.CrossFade(jumpAnimation, animationPlayTransition);

        //        animator.SetBool(jumpParameter, true);



        //        verticalVelocity.y += Mathf.Sqrt(-2f * jumpheight * gravity);
        //    }
        //    if (jump = true)
        //    {
        //        return;
        //    }
        //    jump = false;
        //    animator.SetBool(jumpParameter, false);

        //    //animator.SetBool(jumpParameter, jump);


        //}

        if (crouch)
        {
            print("crouch is true");
            if (isgrounded )
            {
                animator.SetBool("isCrouch",true );
            }
        }
        else
        {
            animator.SetBool("isCrouch", false);
            crouch = false;
            print("crouch is false");
        }
        if (sprint)
        {
            if (isgrounded)
            {
                animator.SetBool(sprintAnimation, true);

            }
        }
        else
        {
            animator.SetBool(sprintAnimation, false);
            sprint = false;

        }
        verticalVelocity.y += gravity * Time.deltaTime;
        controller.Move(verticalVelocity * Time.deltaTime);
        print(isgrounded);
        Debug.Log(animator.GetCurrentAnimatorStateInfo(0));
    }

    public void ReceieveInput(Vector2 _horizontalInput)
    {



        horizontalInput = _horizontalInput;
    }


    public void HandleJump()
    {

        isJumping = inputManager.Jump_Input;

        if (jumpaction.triggered && isgrounded)
        {

            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
            {
                animator.SetTrigger(jumpParameter1);
                print("hi jump");
            }
           

            //animator.SetBool(jumpParameter, true);

            //jumpingVelocity = Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            //playerVelocity = move2Direction;
            //playerVelocity.y = jumpingVelocity;
            //animator.CrossFade(jumpAnimation, animationPlayTransition);
            //if (inputManager.Jump_Input)
            //{
            //    return;
            //}
        }
        else
        {
                animator.ResetTrigger(jumpParameter1);

        }
        if (inputManager.Jump_Input)
        {
            return;
        }

        inputManager.Jump_Input = false;
        //animator.SetBool(jumpParameter, false);



    }

    public void OnJumpPressed()
    {
        jump = true;
    }
    public void OnCrouch()
    {
        crouch = true;
    }
    public void OnSprint()
    {
        sprint = true;
    }


}
