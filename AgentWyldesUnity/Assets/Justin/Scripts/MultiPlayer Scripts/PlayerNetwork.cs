using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Netcode;
public class PlayerNetwork : NetworkBehaviour
{
    // Start is called before the first frame update

    private Rigidbody rigidbodyy;
    private InputAction moveaction;
    CharacterController controller;
    private PlayerInput playerInput;
    Vector2 horizontalInput;
    Vector2 currentAnimationnBlendVector;
    Vector2 animationVelocity;
    Vector3 verticalVelocity = Vector3.zero;
    [SerializeField] float animationSmoothTime = 0.1f;
    PlayerControls controls;
    PlayerControls.GroundMovementActions groundMovement;
    private NetworkVariable<int> randomNuumber = new NetworkVariable<int>(1,NetworkVariableReadPermission.Everyone,NetworkVariableWritePermission.Owner);
    public struct mycustomData//testing things
    {
        public int _int;
        public bool _bool;
    }

    public override void OnNetworkSpawn()
    {
        randomNuumber.OnValueChanged += (int previousValue, int newValue) =>
        {
            Debug.Log(OwnerClientId + "; randomNumber: " + randomNuumber.Value);
        };
    }



    private void Awake()
    {




        //rigidbodyy = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        controls = new PlayerControls();
        groundMovement = controls.GroundMovement;
        controls.GroundMovement.Enable();
        moveaction = playerInput.actions["Horizontal Movement"];

        //controls.GroundMovement.HorizontalMovement.performed += Movement_performed;
    }

    private void Movement_performed(InputAction.CallbackContext obj)
    {
          //randomNuumber.Value = Random.Range(0,100);
        horizontalInput = moveaction.ReadValue<Vector2>();
        currentAnimationnBlendVector = Vector2.SmoothDamp(currentAnimationnBlendVector, horizontalInput, ref animationVelocity, animationSmoothTime);
        Vector3 horizontalVelocity = new Vector3(currentAnimationnBlendVector.x, 0, currentAnimationnBlendVector.y);
        //Vector2 inputVector = obj.ReadValue<Vector2>();
        //float speed = 3f;
        //rigidbodyy.AddForce(new Vector3(inputVector.x,0,inputVector.y)* speed, ForceMode.Force);
    }

    void Start()
    {
        groundMovement.HorizontalMovement.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsOwner)
        {
            return;
        }
        if (moveaction.triggered)
        {
            randomNuumber.Value = Random.Range(0, 100);
        }

        groundMovement.HorizontalMovement.ReadValue<Vector2>();
        horizontalInput = moveaction.ReadValue<Vector2>();
        currentAnimationnBlendVector = Vector2.SmoothDamp(currentAnimationnBlendVector, horizontalInput, ref animationVelocity, animationSmoothTime);
        Vector3 horizontalVelocity = new Vector3(currentAnimationnBlendVector.x, 0, currentAnimationnBlendVector.y);
        controller.Move(horizontalVelocity * Time.deltaTime);




        //Vector2 inputVector = groundMovement.HorizontalMovement.ReadValue<Vector2>();
        //float speed = 1f;
        //rigidbodyy.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * speed, ForceMode.Force); 
        //Vector3 moveDir = new Vector3(0, 0, 0);


        //if (Input.GetKeyDown(KeyCode.W)) moveDir.z = +1F;
        //if (Input.GetKeyDown(KeyCode.S)) moveDir.z = -1F;
        //if (Input.GetKeyDown(KeyCode.A)) moveDir.x = -1F;
        //if (Input.GetKeyDown(KeyCode.D)) moveDir.x = +1F;
        //float movespeed = 3f;
        //transform.position += moveDir * movespeed * Time.deltaTime;

    }
}
