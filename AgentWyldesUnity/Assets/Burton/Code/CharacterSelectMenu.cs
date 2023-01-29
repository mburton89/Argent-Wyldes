
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CharacterSelectMenu : MonoBehaviour
{
    public static CharacterSelectMenu Instance;
    [SerializeField] private Character[] Characters = default; //array of the scriptable objects
    [SerializeField] List<GameObject> playerModels;
    CharacterDatabase characterDatabase;
    int currentPlayerModelIndex;

    [SerializeField] TextMeshProUGUI playerText;
    [SerializeField] TextMeshProUGUI playerTextOutline;

    [SerializeField] Button monsterButton;
    [SerializeField] Button jockButton;
    [SerializeField] Button gothButton;
    [SerializeField] Button cheerleaderButton;
    [SerializeField] Button funGuyButton;
    [SerializeField] Button jesterButton;

    [SerializeField] Button nerdButton;
    [SerializeField] Button partyGuyButton;
    [SerializeField] Button playButton;

    [SerializeField] List<GameObject> buttonOutlines;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        //foreach (var character in Characters)
        //{
        //    GameObject characterInstance = Instantiate(character.CharacterPreviewfab); //creates the preview prefab under the preview parent transform
        //                                                                               //NetworkObject NetworkcharacterInstance = characterInstance.GetComponent<NetworkObject>();
        //                                                                               //NetworkcharacterInstance.SpawnWithOwnership(OwnerClientId);
        //    characterInstance.SetActive(false); //tu;rns off whichever characterInstance isnt being viewed
        //    playerModels.Add(characterInstance); //adds to the the list of which to spawn
        //}
        currentPlayerModelIndex = 2; //Goth
    }

    private void OnEnable()
    {
        //monsterButton.onClick.AddListener(delegate { HandlePlayerSelected(0); });
        jockButton.onClick.AddListener(delegate { HandlePlayerSelected(1); });
        gothButton.onClick.AddListener(delegate { HandlePlayerSelected(2); });
        cheerleaderButton.onClick.AddListener(delegate { HandlePlayerSelected(3); });
        partyGuyButton.onClick.AddListener(delegate { HandlePlayerSelected(4); });
        jesterButton.onClick.AddListener(delegate { HandlePlayerSelected(5); });
        nerdButton.onClick.AddListener(delegate { HandlePlayerSelected(6); });
        playButton.onClick.AddListener(HandlePlayPressed);
    }

    void HandlePlayerSelected(int index)
    {
        playerModels[currentPlayerModelIndex].transform.localScale = Vector3.zero;
        buttonOutlines[currentPlayerModelIndex].SetActive(false);

        PlayerPrefs.SetInt("currentPlayerIndex", index);

        playerModels[PlayerPrefs.GetInt("currentPlayerIndex")].transform.localScale = Vector3.one;

        currentPlayerModelIndex = PlayerPrefs.GetInt("currentPlayerIndex");
        buttonOutlines[currentPlayerModelIndex].SetActive(true);

        playerText.SetText(playerModels[PlayerPrefs.GetInt("currentPlayerIndex")].gameObject.name);
        playerTextOutline.SetText(playerModels[PlayerPrefs.GetInt("currentPlayerIndex")].gameObject.name);

        SoundManager.Instance.buttonClick.Play();
    }





    //void HandlePlayerSelected(int index)
    //{

        



    //    playerModels[currentPlayerModelIndex].transform.localScale = Vector3.zero;
    //    buttonOutlines[currentPlayerModelIndex].SetActive(false);

    //    PlayerPrefs.SetInt("currentPlayerIndex", index);

    //    playerModels[PlayerPrefs.GetInt("currentPlayerIndex")].transform.localScale = Vector3.one;

    //    currentPlayerModelIndex = PlayerPrefs.GetInt("currentPlayerIndex");
    //    buttonOutlines[currentPlayerModelIndex].SetActive(true);

    //    playerText.SetText(playerModels[PlayerPrefs.GetInt("currentPlayerIndex")].gameObject.name);
    //    playerTextOutline.SetText(playerModels[PlayerPrefs.GetInt("currentPlayerIndex")].gameObject.name);

    //    SoundManager.Instance.buttonClick.Play();
    //}

    void HandlePlayPressed()
    {
        SoundManager.Instance.buttonClick.Play();
        SceneManager.LoadScene(2);
    }
}
