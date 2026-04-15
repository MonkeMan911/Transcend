using UnityEngine;

public class EnemyAttackParameterScript : MonoBehaviour
{
    [Header("Shooting Settings")]
    public GameObject projectilePrefab;
    public float shootCooldown = 1f;
    [SerializeField] private float projectileSpawnDistance = 1.5f;

    [Header("Movement")]
    public float speed;
    [Header("References")]
    public Transform player;

    private bool playerInRange = false;
    private bool isShooting = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;

            if (!isShooting)
                StartCoroutine(ShootLoop());

            transform.position = Vector2.Lerp(transform.position, player.position, Time.deltaTime * speed);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private System.Collections.IEnumerator ShootLoop()
    {
        isShooting = true;

        while (playerInRange && !GetComponent<EnemyScript>().isFriend)
        {
            ShootAtPlayer();
            yield return new WaitForSeconds(shootCooldown);
            

        }

        isShooting = false;
    }

    private void Update()
    {
        if (GetComponent<EnemyScript>().isFriend)
            return;
    }
    public void ShootAtPlayer()
    {
        if (player == null) return;

        Vector3 dir = (player.position - transform.position).normalized;

        Vector3 spawnPos = transform.position + dir * projectileSpawnDistance;

        GameObject projectile = Instantiate(projectilePrefab, spawnPos, Quaternion.identity);
        projectile.transform.up = dir;

    }

    private void OnDisable()
    {
        StopAllCoroutines();
        playerInRange = false;
        isShooting = false;
    }

}