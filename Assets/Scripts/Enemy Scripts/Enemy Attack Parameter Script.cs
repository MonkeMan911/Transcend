using UnityEngine;

public class EnemyAttackParameterScript : MonoBehaviour
{
    [Header("Shooting Settings")]
    public GameObject projectilePrefab;
    public float shootCooldown = 1f;

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

        while (playerInRange)
        {
            ShootAtPlayer();
            yield return new WaitForSeconds(shootCooldown);
        }

        isShooting = false;
    }

    public void ShootAtPlayer()
    {
        if (player == null) return;

        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        Vector3 dir = (player.position - transform.position).normalized;

        projectile.transform.up = dir;

        projectile.transform.Translate(Vector2.up * 1.5f, Space.Self);
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        playerInRange = false;
        isShooting = false;
    }

}