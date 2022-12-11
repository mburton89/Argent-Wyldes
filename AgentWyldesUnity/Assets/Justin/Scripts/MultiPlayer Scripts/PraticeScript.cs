using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Cinemachine;
public class PraticeScript : NetworkBehaviour
{

    public CinemachineVirtualCamera playerVCam;

    // Start is called before the first frame update
    public override void OnNetworkSpawn()
    {
        if (IsLocalPlayer)
        {
            return;

            
        }
        playerVCam.enabled = false;
    }


}
