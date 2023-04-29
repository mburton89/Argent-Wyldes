using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class LeshenAI : MonoBehaviour
{
    public Movement movement;
    public NavMeshAgent AI;
    public Animator anim;
    public Transform player;
    Vector3 dest;

    private void Start()
    {
       movement = FindObjectOfType<Movement>();
    }
    private void Update()
    {
        dest = player.position;
        AI.destination= dest;
        if (movement.ritualCollected == 1)
        {
            AI.speed = 1.5f;
            anim.speed = 0.1f;
        }
        if (movement.ritualCollected == 2)
        {
            AI.speed = 1.7f;
            anim.speed = 0.2f;

        }
        if (movement.ritualCollected == 3)
        {
            AI.speed = 2.0f;
            anim.speed = 0.3f;

        }
        if (movement.ritualCollected == 4)
        {
            AI.speed = 2.5f;
            anim.speed = 0.4f;

        }
        if (movement.ritualCollected == 5)
        {
            AI.speed = 3f;
            anim.speed = 0.5f;

        }

    }



}
