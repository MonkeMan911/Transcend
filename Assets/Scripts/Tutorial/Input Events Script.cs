using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputEventsScript : MonoBehaviour
{
    [SerializeField] UnityEvent pressE;
    [SerializeField] GameObject hoverSign;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hoverSign.SetActive(true);
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        hoverSign.SetActive(false);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
             pressE.Invoke();
        }
    }
}
