using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItemInterable : InteractableObject
{
    [SerializeField] Item item;
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
        player.playerInventory.itemsInInventory.Add(item);
       
    }







}
