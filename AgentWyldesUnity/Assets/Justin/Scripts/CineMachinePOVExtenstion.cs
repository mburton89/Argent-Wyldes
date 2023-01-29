using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CineMachinePOVExtenstion : CinemachineExtension
{
    private InputManager inputManager;
    private Vector3 startingRotation;
    [SerializeField]private float clampAngle = 80f;
    [SerializeField] private float horizontalSpeed = 10f;
    [SerializeField] private float verticalSpeed = 10f;

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (vcam.Follow)
        {
            if (stage == CinemachineCore.Stage.Aim)
            {
                if (startingRotation == null)
                {
                    startingRotation = transform.localRotation.eulerAngles;
                    Vector2 deltaInput = inputManager.mounseInput;
                    startingRotation.x += verticalSpeed*deltaInput.x * Time.deltaTime;
                    startingRotation.y += horizontalSpeed*deltaInput.y * Time.deltaTime;
                    startingRotation.y = Mathf.Clamp(startingRotation.y, -clampAngle, clampAngle);
                    state.RawOrientation = Quaternion.Euler(-startingRotation.y, startingRotation.x, 0f);

                }

            }
        }
    }
     
    protected override void Awake()
    {
        inputManager = InputManager.instance;
        base.Awake();
    }
   
}
