using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerNetwork : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody rigidbodyy;
    private PlayerInput playerInput;
    private void Awake()
    {
        rigidbodyy = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        PlayerControls inputActions = new PlayerControls();
        inputActions.GroundMovement.Enable();
        inputActions.GroundMovement.HorizontalMovement.performed += Movement_performed;
    }

    private void Movement_performed(InputAction.CallbackContext obj)
        {

        Vector2 inputVector = obj.ReadValue<Vector2>();
        float speed = 3f;
        rigidbodyy.AddForce(new Vector3(inputVector.x,0,inputVector.y)* speed, ForceMode.Force);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 moveDir = new Vector3(0, 0, 0);


        //if (Input.GetKeyDown(KeyCode.W)) moveDir.z = +1F;
        //if (Input.GetKeyDown(KeyCode.S)) moveDir.z = -1F;
        //if (Input.GetKeyDown(KeyCode.A)) moveDir.x = -1F;
        //if (Input.GetKeyDown(KeyCode.D)) moveDir.x = +1F;
        //float movespeed = 3f;
        //transform.position += moveDir * movespeed * Time.deltaTime;

    }
}
