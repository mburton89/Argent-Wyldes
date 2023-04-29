using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadCharacter : MonoBehaviour
{


    public Character[] characters;
    public List<GameObject> characterPrefabs;
    public Transform spawnPoint;
    public TMP_Text label;
    // Start is called before the first frame update
    private void Awake()
    {
        foreach (var character in characters)
        {
            GameObject characterInstance = Instantiate(character.CharacterGameplayPrefab); //creates the preview prefab under the preview parent transform
                                                                                       //NetworkObject NetworkcharacterInstance = characterInstance.GetComponent<NetworkObject>();
                                                                                       //NetworkcharacterInstance.SpawnWithOwnership(OwnerClientId);
            characterInstance.SetActive(false); //tu;rns off whichever characterInstance isnt being viewed
            characterPrefabs.Add(characterInstance); //adds to the the list of which to spawn
            
        }

    }
    void Start()
    {
        int selectedCharacter = PlayerPrefs.GetInt("currentPlayerIndex");
        GameObject prefab = characterPrefabs[selectedCharacter];
        GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        clone.SetActive(true);
        label.text = prefab.name;
        foreach( GameObject character in characterPrefabs ) 
        {
            if (character != clone)
            {
                Destroy(character);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
