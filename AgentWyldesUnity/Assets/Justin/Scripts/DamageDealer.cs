using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    //public HealthSystem healthSystem;
    public int damageAmount;
    public GameObject colliderGameObject;
    public Collider col;
    
    // Start is called before the first frame update
    void Start()
    {
       col = colliderGameObject.GetComponentInChildren<BoxCollider>();   
            //GetComponent<Collider>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider hitTarget)
    {
        if (hitTarget.CompareTag ("Player"))
        {
            print("hit/damagedealt");
            //hitTarget.gameObject.TryGetComponent(out HealthSystem player);
            //player.TakeDamage(damageAmount);
        }
    }
    public void SetActiveCollider(int triggervalue)
    {
        if (col != null)
        {
            if(triggervalue == 1)
            {
                col.enabled = true;
            }
            else
            {
                col.enabled = false;
            }
        }


    }


}
