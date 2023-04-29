using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionManager : MonoBehaviour
{
    
    //handle open door
    //add item to inventory
   public Inventory playerInventory;
    
    // Start is called before the first frame update
    void Start()
    {
        playerInventory= GetComponent<Inventory>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (playerInventory.itemsInInventory.Count == 6)
        {
            FindObjectOfType<gamemanager>().CompleteGame();
        }
    }
}
