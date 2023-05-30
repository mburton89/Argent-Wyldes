using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOff : MonoBehaviour
{
    [SerializeField] GameObject updateCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        StartCoroutine(ResetText());

    }

    private void TurnOffCanvas()
    {
        updateCanvas.SetActive(false);
    }
    IEnumerator ResetText()
    {
        yield return new WaitForSeconds(3f);

        TurnOffCanvas();

    }
}
