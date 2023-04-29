using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class testgameender : MonoBehaviour
{
    public Button gameendbutton;
    public Button completegamebutton;
    public gamemanager gamemanager;


    
    public void TestEndGame ()
    {
    FindObjectOfType<gamemanager>().Endgame();
    
    
    }
    
  public   void testCompletegame()
    {
        FindObjectOfType<gamemanager>().CompleteGame();
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
