using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackScript : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<PlayerCourageScript>().ChangeCourage(-damage);
    }
}
