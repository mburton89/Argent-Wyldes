
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelectMenu : MonoBehaviour
{
    public static CharacterSelectMenu Instance;

    [SerializeField] List<GameObject> playerModels;
    Transform currentPlayerModel;
    [SerializeField] Button monsterButton;
    [SerializeField] Button jockButton;
    [SerializeField] Button gothButton;
    [SerializeField] Button nerdButton;
    [SerializeField] Button jesterButton;
    [SerializeField] Button funGuyButton;
    [SerializeField] Button partyGuyButton;
    [SerializeField] Button playButton;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        currentPlayerModel = playerModels[2].transform;
    }

    private void OnEnable()
    {
        monsterButton.onClick.AddListener(delegate { HandlePlayerSelected(0); });
        jockButton.onClick.AddListener(delegate { HandlePlayerSelected(1); });
        gothButton.onClick.AddListener(delegate { HandlePlayerSelected(2); });
        nerdButton.onClick.AddListener(delegate { HandlePlayerSelected(3); });
        jesterButton.onClick.AddListener(delegate { HandlePlayerSelected(4); });
        funGuyButton.onClick.AddListener(delegate { HandlePlayerSelected(5); });
        partyGuyButton.onClick.AddListener(delegate { HandlePlayerSelected(6); });
        playButton.onClick.AddListener(HandlePlayPressed);
    }

    void HandlePlayerSelected(int index)
    {
        currentPlayerModel.localScale = Vector3.zero;
        PlayerPrefs.SetInt("currentPlayerIndex", index);
        playerModels[PlayerPrefs.GetInt("currentPlayerIndex")].transform.localScale = Vector3.one;
        currentPlayerModel = playerModels[PlayerPrefs.GetInt("currentPlayerIndex")].transform;
    }

    void HandlePlayPressed()
    {
        SceneManager.LoadScene(2);
    }
}
