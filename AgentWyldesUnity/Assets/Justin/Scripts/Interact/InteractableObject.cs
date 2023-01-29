using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{

    //base class for interactable object
    protected Movement movement;
    [SerializeField]protected GameObject interactableCanvas; //the image indicating a player can interact
    [SerializeField]protected Collider interactablebleatCollider; //th colider enabling interaction when the player is close enough for interaction

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (movement == null)
        {
            movement = other.GetComponent<Movement>();
        }
        if (movement != null)
        {
            interactableCanvas.SetActive(true);
            movement.canInteract = true;
        }
    }

    protected virtual void OnTriggerStay(Collider other)
    {
        if (movement != null)
        {
            if (movement.inputManager.Interact_Input)
            {
                Interact(movement);
                movement.inputManager.Interact_Input = false;
            }
        }

    }


    protected virtual void OnTriggerExit(Collider other)
    {
        if (movement == null)
        {
            movement = other.GetComponent<Movement>();
        }
        if (movement != null)
        {
            interactableCanvas.SetActive(false);
            movement.canInteract = false;
        }
    }

    protected virtual void Interact(Movement player)
    {

        Debug.Log("You have Interacted");

    }
}
