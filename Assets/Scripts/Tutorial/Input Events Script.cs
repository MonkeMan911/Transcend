using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputEventsScript : MonoBehaviour
{
    [SerializeField] UnityEvent pressE;
    [SerializeField] GameObject hoverSign;
    [SerializeField] GameObject player;

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
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player In Collision");
            if (Input.GetKeyDown(KeyCode.E))
            {
                pressE.Invoke();
                Debug.LogWarning("Event Invoked");
            }
        }
    }
}
