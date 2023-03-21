using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    //public GameObject[] characterPrefabs;
    //public Transform spawnPoint;

    [SerializeField] Slider volumeSlider;

    //private void LoadCharacter()
    //{
    //    int selectedCharacter = PlayerPrefs.GetInt("currentPlayerIndex");
    //    GameObject prefab = characterPrefabs[selectedCharacter];
    //    GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
    //}

    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame ()
    {
        Debug.Log ("EXIT!");
        Application.Quit();
    }

    public void start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musiccolume", 1);
            load();
        }

        else
        {
            load();
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Debug.Log("volume is" + volumeSlider.value);
        Save();
    }
    public void load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }

}

