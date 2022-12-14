using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using TMPro;


public class CharacterSelection : NetworkBehaviour
{

    [SerializeField] private GameObject characterSelectDispaly = default; //all the characters total
    [SerializeField] private Transform characterPreviewParent = default; //will spawn the preview character
    [SerializeField] private TMP_Text characterNameText = default;
    [SerializeField] private float turnspeed = 90f; // how fast the player rotates when viewing
    [SerializeField] private Character[] Characters = default; //array of the scriptable objects
    private NetworkObject playerToSpawn;

    private int currentCharacterIndex = 0; //which character is current showing 
    private List<GameObject> characterInstances = new List<GameObject>(); //how many characters are avaible or if it is hovered or not 
    private ulong cilentId;

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        //if (characterPreviewParent.childCount ==0)
        //{
            foreach (var character in Characters)
            {
                GameObject characterInstance = Instantiate(character.CharacterPreviewfab, characterPreviewParent); //creates the preview prefab under the preview parent transform
            //NetworkObject NetworkcharacterInstance = characterInstance.GetComponent<NetworkObject>();
            //NetworkcharacterInstance.SpawnWithOwnership(OwnerClientId);
                characterInstance.SetActive(false); //tu;rns off whichever characterInstance isnt being viewed
                characterInstances.Add(characterInstance); //adds to the the list of which to spawn
            }
        //}
       
        characterInstances[currentCharacterIndex].SetActive(true); // turns on current index otherwise it is false 
        characterNameText.text = Characters[currentCharacterIndex].CharacterName; //ui text is set to the name of the scriptable object


        characterSelectDispaly.SetActive(true);

    }


    public void Right()
    {
        characterInstances[currentCharacterIndex].SetActive(false);// turns off current preview
        currentCharacterIndex = (currentCharacterIndex + 1) % characterInstances.Count;// looks up % but it goes to start if we go past the count
        //moves index by one


        characterInstances[currentCharacterIndex].SetActive(true);//turns on the new index
        characterNameText.text = Characters[currentCharacterIndex].CharacterName; 

    }
    public void Left()
    {
        characterInstances[currentCharacterIndex].SetActive(false);
        currentCharacterIndex--;
        if (currentCharacterIndex <0)
        {
            currentCharacterIndex += characterInstances.Count;
        }


        characterInstances[currentCharacterIndex].SetActive(true);
        characterNameText.text = Characters[currentCharacterIndex].CharacterName;
    }

    public void Select()
    {
        //if (!IsOwner)
        //{
        //    return;
        //}
        //characterSelect(currentCharacterIndex);
        //GameObject characterInstance = Instantiate(Characters[currentCharacterIndex].CharacterGameplayPrefab);
        //NetworkObject characterToSpawn = characterInstance.GetComponent<NetworkObject>();
        //playerToSpawn = characterToSpawn;
        //characterInstance.SetActive(true);
        //playerToSpawn.SpawnAsPlayerObject(OwnerClientId, true);
        //SpawnCharacteClientRpc(/*NetworkManager.Singleton.LocalClientId*/);
        if (IsHost)
        {
            //characterSelect(currentCharacterIndex);
            GameObject characterInstance = Instantiate(Characters[currentCharacterIndex].CharacterGameplayPrefab);
            NetworkObject characterToSpawn = characterInstance.GetComponent<NetworkObject>();
            playerToSpawn = characterToSpawn;
            //characterInstance.SetActive(true);
            playerToSpawn.SpawnAsPlayerObject(NetworkManager.Singleton.LocalClientId);
            characterSelectDispaly.SetActive(false);
        }
        else
        {
            SpawnCharacterServerRpc(currentCharacterIndex, NetworkManager.Singleton.LocalClientId);
            //SpawnCharacteClientRpc(currentCharacterIndex, NetworkManager.Singleton.LocalClientId);
            characterSelectDispaly.SetActive(false);
        }
        //SpawnCharacterServerRpc(NetworkManager.Singleton.LocalClientId);
        Debug.Log(OwnerClientId);
        //characterSelectDispaly.SetActive(false);
    }
    public void characterSelect(int characterIndex)
    {
        GameObject characterInstance = Instantiate(Characters[characterIndex].CharacterGameplayPrefab);
        characterInstance.GetComponent<NetworkObject>().Spawn();
        
    }
    [ServerRpc(RequireOwnership = false)]
    //private void SpawnCharacterServerRpc(ServerRpcParams serverRpcParams = default)
    private void SpawnCharacterServerRpc(int charaterIndex,ulong clientId)
    {
        //public void SpawnPlayerServerRpc(ulong clientId, int prefabId)
        //{
        //    GameObject newPlayer;
        //    if (prefabId == 0)
        //        newPlayer = (GameObject)Instantiate(playerPrefabA);
        //    else
        //        newPlayer = (GameObject)Instantiate(playerPrefabB);
        //    netObj = newPlayer.GetComponent<NetworkObject>();
        //    newPlayer.SetActive(true);
        //    netObj.SpawnAsPlayerObject(clientId, true);

        //}
        //var clientId = serverRpcParams.Receive.SenderClientId;
        //if (NetworkManager.ConnectedClients.ContainsKey(clientId))
        //{
        //    var client = NetworkManager.ConnectedClients[clientId];
            GameObject characterInstance = Instantiate( Characters[charaterIndex].CharacterGameplayPrefab);
            NetworkObject characterToSpawn = characterInstance.GetComponent<NetworkObject>();
            playerToSpawn = characterToSpawn;
            //characterInstance.SetActive(true);
            playerToSpawn.SpawnAsPlayerObject(clientId, true);


        //}
        
           


        //if (!IsOwner)
        //{
        //    return;
        //}

        //playerToSpawn.SpawnAsPlayerObject(OwnerClientId);
    }
    [ClientRpc]
    private void SpawnCharacteClientRpc(int charaterIndex, ulong clientId)
    {
        //if (!IsOwner)
        //{
        //    return;
        //}
        //GameObject characterInstance = Characters[currentCharacterIndex].CharacterGameplayPrefab;
        //NetworkObject characterToSpawn = characterInstance.GetComponent<NetworkObject>();
        //playerToSpawn = characterToSpawn;
        //characterInstance.SetActive(true);
        //playerToSpawn.SpawnAsPlayerObject(OwnerClientId, true);


        GameObject characterInstance = Instantiate(Characters[charaterIndex].CharacterGameplayPrefab);
        NetworkObject characterToSpawn = characterInstance.GetComponent<NetworkObject>();
        playerToSpawn = characterToSpawn;
        //characterInstance.SetActive(true);
        playerToSpawn.SpawnAsPlayerObject(clientId, true);
    }
}
