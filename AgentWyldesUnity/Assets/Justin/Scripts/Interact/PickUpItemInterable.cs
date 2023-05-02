using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PickUpItemInterable : InteractableObject
{
    [SerializeField] Item item;
    [SerializeField] GameObject monster;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform spawnPosition;

    private void Start()
    {
        
    }
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
        if(monster.activeInHierarchy == false)
        {
            monster.transform.position = spawnPosition.position;

            monster.SetActive(true);

        }
        else
        {
            monster.SetActive(false);
            agent.enabled = false;
            monster.transform.position = spawnPosition.position;
            agent.enabled = true;
            monster.SetActive(true);
        }
        //monster.transform.position = spawnPosition.position;
        Destroy(gameObject);
       
    }







}
