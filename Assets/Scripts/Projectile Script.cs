using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float speed = 10f;
    public float deathDistance = 20f;
    public float homingDistance = 10f;

    public Transform enemyPos;
    private Transform player;
    [SerializeField] private Transform proj;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyPos = FindClosestEnemy();
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    Transform FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        Transform closest = null;
        float minDist = Mathf.Infinity;

        foreach (GameObject e in enemies)
        {
            float dist = Vector2.Distance(transform.position, e.transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                closest = e.transform;
            }
        }

        return closest;
    }

    void Update()
    {
        if (enemyPos == null)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
            return;
        }

        float distanceToEnemy = Vector2.Distance(transform.position, enemyPos.position);

        // Homing behavior
        if (distanceToEnemy < homingDistance)
        {
            // Rotate toward enemy
            Vector2 dir = (enemyPos.position - transform.position).normalized;
            transform.up = dir;

            // Move in new direction
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else
        {
            // Normal forward movement
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }

        if(Vector2.Distance(transform.position, player.position) > deathDistance)
            Destroy(gameObject);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hit Enemy!");
            Destroy(gameObject);
        }
    }
}