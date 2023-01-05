using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //public GameObject[] characterPrefabs;
    //public Transform spawnPoint;

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
}
