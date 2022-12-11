using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;


public class HealthSystem : NetworkBehaviour
{
    public int health;
    public int maxHealth = 4;


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }
    public void TakeDamage(int amount)
    {

        health -= amount;
        if (health<= 0)
        {
            Destroy(gameObject);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
