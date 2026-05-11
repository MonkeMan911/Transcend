using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhase2BoxHoverScript : MonoBehaviour
{
    [Header("Separate Scripts")]
    [SerializeField] BossHealthScript phases;

    [Header("Progression Nums")]
    [SerializeField] int boxProgress1 = 0 , boxProgress2 = 0, boxProgress3 = 0, boxProgress4 = 0;

    [Header("Boxes")]
    [SerializeField] GameObject BoxDaddy, Box1, Box2, Box3, Box4;

    [Header("Box Bools")]
    [SerializeField] bool isbox1, isbox2, isbox3, isbox4;
    void Start()
    {
        BoxDaddy.SetActive(false);
        Box1.GetComponent<Collider2D>();
        Box2.GetComponent<Collider2D>();
        Box3.GetComponent<Collider2D>();
        Box4.GetComponent<Collider2D>();
    }
    void Update()
    {
        if (phases.isPhase2) 
        {
            BoxDaddy.SetActive(true);
        }

        if (isbox1 && isbox2 && isbox3 && isbox4) 
        {
            
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (phases.isPhase2) 
        {
            if (collision.CompareTag("Player") && Box1)
            {
                boxProgress1++;
            }
        }
    }
}
