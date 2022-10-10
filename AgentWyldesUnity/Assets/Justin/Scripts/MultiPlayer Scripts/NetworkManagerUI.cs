using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using TMPro;

public class NetworkManagerUI : MonoBehaviour
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

            NetworkManager.Singleton.StartHost();
        }); clientBtn.onClick.AddListener(() =>
        {

            NetworkManager.Singleton.StartClient();
        });

        Cursor.visible = true;

    }

    private void Update()
    {
        //playersInGameText.text = "Players in Game:" {PlayerManager.Instace.PlayersInGame}";
    }

    


}
