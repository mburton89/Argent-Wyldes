using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardWorldUI : MonoBehaviour
{
    Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (mainCamera != null)
        {
            transform.LookAt(mainCamera.transform.position + mainCamera.transform.forward);
        }
    }
}
