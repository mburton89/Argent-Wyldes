using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Netcode;
using Cinemachine;

public class NetworkMovement : NetworkBehaviour
{
    // Start is called before the first frame update


    [SerializeField] CharacterController controller;
    [SerializeField] PlayerControls inputActions;
    [SerializeField] NetWorkInputManger inputManager;
    [SerializeField] PlayerInput playerInput;
    [SerializeField] float speed = 11f;
    [SerializeField] float crouchspeed = 1.1f;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] LayerMask groundmask;
    [SerializeField] float jumpheight = 3.5f;
    [SerializeField] float animationSmoothTime = 0.1f;
    [SerializeField] Transform followTarget;

    private Animator animator;
    private GameObject playerCamera;
    private GameObject _mainCamera;
    private CinemachineVirtualCamera _cinemachineVirtualCamera;


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
    bool isJumping;
    Vector2 currentAnimationnBlendVector;
    Vector2 animationVelocity;
    Vector3 verticalVelocity = Vector3.zero;
    Vector2 horizontalInput;
    private float animationPlayTransition = 0.15f;
    private int jumpParameter1;

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        if (IsClient  && IsOwner)
        {
            playerInput = GetComponent<PlayerInput>();
            playerInput.enabled = true;
            _cinemachineVirtualCamera.Follow = followTarget;
        }
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
        inputManager = GetComponent<NetWorkInputManger>();
        jumpAnimation = Animator.StringToHash("Jump");
        crouchAnimation = Animator.StringToHash("Jump");

        moveaction = playerInput.actions["Horizontal Movement"];
        jumpaction = playerInput.actions["Jump"];
        crouchaction = playerInput.actions["Crouch"];
        if (_mainCamera == null)
        {
            _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        }
        if (_cinemachineVirtualCamera == null)
        {
            _cinemachineVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        }

        //playerCamera = GameObject.FindGameObjectWithTag("PlayerCamera");

        moveXParameterId = Animator.StringToHash("MoveX");
        jumpParameter = Animator.StringToHash("isJumping");
        jumpParameter1 = Animator.StringToHash("isJumping1");

        moveZParameterId = Animator.StringToHash("MoveZ");
    }
    private void Update()
    {

        if (!IsOwner)
        {
            return;
        }
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

        Vector3 horizontalVelocity = new Vector3(currentAnimationnBlendVector.x, 0, currentAnimationnBlendVector.y);
        if (crouch)
        {
            horizontalVelocity = (transform.right.normalized * horizontalVelocity.x + transform.forward.normalized * horizontalVelocity.z) * crouchspeed;
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
            if (isgrounded)
            {
                animator.SetBool("isCrouch", true);
            }
        }
        else
        {
            animator.SetBool("isCrouch", false);
            crouch = false;
            print("crouch is false");
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


}
