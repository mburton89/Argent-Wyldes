using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorTrigger : MonoBehaviour
{
    [SerializeField]
    private float maxUseDistance = 5f;
    [SerializeField]
    private LayerMask UseLayers;
    [SerializeField]
    private Transform Camera;



    
    public void UseDoor()
    {
        if (Physics.Raycast(Camera.position,Camera.forward,out RaycastHit hit,maxUseDistance,UseLayers))
        {
            if (hit.collider.TryGetComponent<Door>(out Door door))
            {
                if (door.isOpen)
                {
                    door.Close();


                }
                else
                {
                    door.open(transform.position);
                }
            }
        }


    }

    private void Update()

    {
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    UseDoor();
        //}
        Debug.DrawRay(Camera.position, Camera.forward, Color.blue, 0.1f);
    }
}
