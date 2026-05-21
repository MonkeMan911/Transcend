using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputEventsScript : MonoBehaviour
{
    [SerializeField] UnityEvent pressE;
    [SerializeField] GameObject hoverSign;
    [SerializeField] GameObject player;
    [SerializeField] bool isInTrigger;
    private void Update()
    {
        if (isInTrigger && Input.GetKeyDown(KeyCode.E)) 
        {
            pressE.Invoke();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {    
            hoverSign.SetActive(true);
            isInTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hoverSign.SetActive(false);
            isInTrigger = false;
        }
    }
}
