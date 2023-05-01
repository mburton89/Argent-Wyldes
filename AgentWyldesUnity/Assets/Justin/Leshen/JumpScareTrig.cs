using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScareTrig : MonoBehaviour
{
    public GameObject playerObj, jumpscareCam, ambienceLayers;
    public Animator monsterAnim;
    public LeshenAI leshenAI;
    public float jumpscareTime;

    private void Start()
    {
        playerObj = FindObjectOfType<Movement>().gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.TryGetComponent<Movement>(out Movement player))
        {
            playerObj.SetActive(false);
            jumpscareCam.SetActive(true);
            leshenAI.enabled = false;
            monsterAnim.speed = 1;
            monsterAnim.SetTrigger("JumpScare");
            StartCoroutine(endgame());
        }


    }

    IEnumerator endgame() 
    {
    
    yield return new WaitForSeconds(jumpscareTime);
        FindObjectOfType<gamemanager>().Endgame();

    }



}
