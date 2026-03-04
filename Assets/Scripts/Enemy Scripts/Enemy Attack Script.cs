using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackScript : MonoBehaviour
{
    [SerializeField] private int anxiety = 1;

    public void Start()
    {
        GetComponent<Collider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerAnxietyScript anxietyScript = collision.gameObject.GetComponent<PlayerAnxietyScript>();

        if (anxietyScript != null)
        {
            anxietyScript.ChangeAnxiety(anxiety);
        }
    }

}
