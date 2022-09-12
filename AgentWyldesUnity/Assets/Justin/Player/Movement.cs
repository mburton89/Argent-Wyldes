using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField] CharacterController controller;
    [SerializeField] PlayerControls inputActions;
    [SerializeField] InputManager inputManager;
    [SerializeField] PlayerInput playerInput;
    [SerializeField] float speed = 11f;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] LayerMask groundmask;
    [SerializeField] float jumpheight = 3.5f;
    [SerializeField] float animationSmoothTime = 0.1f;

    private Animator animator;
   
    int moveXParameterId;
    private InputAction moveaction;
    private InputAction jumpaction;
    int moveZParameterId;
    int jumpAnimation;
    bool jump;
    bool isgrounded;
    Vector2 currentAnimationnBlendVector;
    Vector2 animationVelocity;
    Vector3 verticalVelocity = Vector3.zero;
    Vector2 horizontalInput;
    private float animationPlayTransition = 0.15f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
        inputManager = GetComponent<InputManager>();
        jumpAnimation = Animator.StringToHash("Jump");

        moveaction = playerInput.actions["Horizontal Movement"];
        jumpaction = playerInput.actions["Jump"];

        moveXParameterId = Animator.StringToHash("MoveX");
        moveZParameterId = Animator.StringToHash("MoveZ");
    }
    private void Update()
    {
        
        

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
        horizontalVelocity = (transform.right.normalized * horizontalVelocity.x + transform.forward.normalized * horizontalVelocity.z) * speed;
        controller.Move(horizontalVelocity * Time.deltaTime);
        animator.SetFloat(moveXParameterId, currentAnimationnBlendVector.x);
        animator.SetFloat(moveZParameterId, currentAnimationnBlendVector.y);

        //jump height equation: v = sqrt(-2 * jumpheight * gravity
        if (jump)
        {
            if (isgrounded & jumpaction.triggered)
            {
                verticalVelocity.y += Mathf.Sqrt(-2f * jumpheight * gravity);
                animator.CrossFade(jumpAnimation, animationPlayTransition);
            }
            jump = false;
        }



        verticalVelocity.y += gravity * Time.deltaTime;
        controller.Move(verticalVelocity * Time.deltaTime);
        print(isgrounded);
    }

    public void ReceieveInput(Vector2 _horizontalInput)
    {



        horizontalInput = _horizontalInput;
    }

    public void OnJumpPressed()
    {
        jump = true;
    }



}
