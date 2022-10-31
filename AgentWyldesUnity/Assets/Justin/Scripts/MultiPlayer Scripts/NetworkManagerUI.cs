using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using TMPro;

public class NetworkManagerUI : NetworkBehaviour
{


    [SerializeField] private Button serverBtn;
    [SerializeField] private Button hostBtn;
    [SerializeField] private Button clientBtn;
    [SerializeField] private TextMeshProUGUI playersInGameText;





    private void Awake()
    {

        serverBtn.onClick.AddListener(() =>
        {

            NetworkManager.Singleton.StartServer();
        }); hostBtn.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.ConnectionApprovalCallback = ApprovalCheck;

            NetworkManager.Singleton.StartHost();

        }); clientBtn.onClick.AddListener(() =>
        {

            NetworkManager.Singleton.StartClient();
        });

        Cursor.visible = true;

    }
    private void ApprovalCheck(NetworkManager.ConnectionApprovalRequest request, NetworkManager.ConnectionApprovalResponse response)
    {


        // The client identifier to be authenticated
        var clientId = request.ClientNetworkId;

        // Additional connection data defined by user code
        var connectionData = request.Payload;

        // Your approval logic determines the following values
        response.Approved = true;
        response.CreatePlayerObject = true;

        // The prefab hash value of the NetworkPrefab, if null the default NetworkManager player prefab is used
        response.PlayerPrefabHash = null;

        // Position to spawn the player object (if null it uses default of Vector3.zero)
        response.Position = Vector3.zero;

        // Rotation to spawn the player object (if null it uses the default of Quaternion.identity)
        response.Rotation = Quaternion.identity;

        // If additional approval steps are needed, set this to true until the additional steps are complete
        // once it transitions from true to false the connection approval response will be processed.
        response.Pending = false;
    }

    private void Update()
    {
        //playersInGameText.text = "Players in Game:" {PlayerManager.Instace.PlayersInGame}";
    }

    


}
