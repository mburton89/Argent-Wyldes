using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen = false;
    [SerializeField]
    private bool IsRotatingDoor = true;
    [SerializeField]
    private float speed = 1f;
    [Header("RotationConfigs")]
    [SerializeField]
    private float rotationAmount = 90f;
    [SerializeField]
    private float forwardDirection = 0;


    private Vector3 StartRotation;
    private Vector3 Forward;

    private Coroutine AnimationCoroutine;


    private void Awake()
    {
        StartRotation = transform.rotation.eulerAngles;
        Forward = transform.right;
    }
    public void open(Vector3 UserPosition)
    {

        if (!isOpen)
        {
            if (AnimationCoroutine != null)
            {
                StopCoroutine(AnimationCoroutine);
            }
            if (IsRotatingDoor)
            {
                float dot = Vector3.Dot(Forward, (UserPosition - transform.position).normalized);
                //Debug.Log($"Dot:"{dot.ToString("N3")});
                AnimationCoroutine = StartCoroutine(DoRotationOpen(dot));
            }
        }

    }

    private IEnumerator DoRotationOpen(float ForwardAmount)
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation;
        if (ForwardAmount >= forwardDirection)
        {
            endRotation = Quaternion.Euler(new Vector3(0, StartRotation.y - rotationAmount, 0));
        }
        else
        {
            endRotation = Quaternion.Euler(new Vector3(0, StartRotation.y + rotationAmount, 0));
        }
        isOpen = true;
        float time = 0;
        while (time < 1)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, time);
            yield return null;
            time += Time.deltaTime * speed;
        }
    }

    public void Close()
    {

        if (isOpen)
        {
            if (AnimationCoroutine != null)
            {
                StopCoroutine(AnimationCoroutine);
            }
        }
        if (IsRotatingDoor)
        {
            AnimationCoroutine = StartCoroutine(DoRotationClose());
        }
    }
    private IEnumerator DoRotationClose()
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(StartRotation);
        isOpen = false;
        float time = 0;
        while (time < 1)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, time);
            yield return null;
            time += Time.deltaTime * speed;

        }
     
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
