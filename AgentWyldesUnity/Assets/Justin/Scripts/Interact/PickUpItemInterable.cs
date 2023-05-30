using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using TMPro;

public class PickUpItemInterable : InteractableObject
{
    [SerializeField] Item item;
    [SerializeField] GameObject monster;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform spawnPosition;
    [SerializeField] GameObject updateCanvas;
    [SerializeField] TextMeshProUGUI updatetext;

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
        //int ritualcollect = player.playerInventory.itemsInInventory.Count;
        if (updateCanvas.activeInHierarchy == false)
        {
            updateCanvas.SetActive(true);
        }
        updatetext.text = "Ritual Objects Collected " + player.playerInventory.itemsInInventory.Count /*+ "/" + 6*/ ;
        //StartCoroutine(ResetText());

        if (monster.activeInHierarchy == false)
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
    //private void TurnOffCanvas()
    //{
    //    updateCanvas.SetActive(false);
    //}
    //IEnumerator ResetText()
    //{
    //    yield return new WaitForSeconds(3f);
      
    //       TurnOffCanvas();
        
    //}





}
