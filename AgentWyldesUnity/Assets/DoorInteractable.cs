using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractable : InteractableObject
{
    [SerializeField] Animator doorAnimator;


    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }

    protected override void OnTriggerStay(Collider other)
    {
        base.OnTriggerStay(other);
    }

    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
    }

    protected override void Interact(Movement player)
    {
        base.Interact(player);
        interactableCanvas.SetActive(false);
        doorAnimator.Play("Door");
    }



}
