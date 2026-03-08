using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttackParameterScript : MonoBehaviour
{
    public enemyShoot shoot;
    [SerializeField] private bool shootBool;
    [SerializeField] private float singleShootCD;

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            shootBool = true;
            StartCoroutine(EnemyShootSingle());
        }
    }

    public void EnemyShootPlayer()
    {
        GameObject projectile = Instantiate(shoot.prefab);

        projectile.transform.position = transform.position;

        Vector3 dir = projectile.transform.position;
        projectile.transform.up = dir;

        projectile.transform.Translate(Vector2.up * 1.5f);
    }

    IEnumerator EnemyShootSingle() 
    {
        yield return new WaitForSeconds(singleShootCD);
        while (shootBool == true)
        {
            EnemyShootPlayer();
        }
        shootBool = false;
    }
}

[System.Serializable]
public struct enemyShoot
{
    public GameObject prefab;
}
