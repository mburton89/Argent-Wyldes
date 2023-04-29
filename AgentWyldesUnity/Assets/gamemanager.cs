using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{


    bool gamehasEnded = false;
    public GameObject completeGameUI;
    public GameObject gameOverUI;


    public void CompleteGame()
    {

        completeGameUI.SetActive(true);
    }
    public void Endgame()
    {
        if (gamehasEnded == false)
        {
            gamehasEnded = true;
            Debug.Log("game over");
            gameOverUI.SetActive(true);
        }

    }

    private void Restart()
    {
        SceneManager.LoadScene("Main Menu");
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
