using UnityEngine;

public class EnemyProjectileScript : MonoBehaviour
{
    public float speed = 10f;
    public float deathDistance = 20f;
    public float homingDistance = 10f;
    [SerializeField] private int anxiety;

    public Transform playerPos;
    private Transform enemy;
    [SerializeField] private Transform proj;

    void Start()
    {
        enemy = transform.parent; // the enemy that fired this projectile

        if (enemy != null)
        {
            Collider2D enemyCol = enemy.GetComponent<Collider2D>();
            Collider2D projCol = GetComponent<Collider2D>();

            if (enemyCol != null && projCol != null)
                Physics2D.IgnoreCollision(enemyCol, projCol);
        }
    }




    void Update()
    {
        if (playerPos == null)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
            return;
        }

        float distanceToEnemy = Vector2.Distance(transform.position, playerPos.position);

        // Homing behavior
        if (distanceToEnemy < homingDistance)
        {
            // Rotate toward Player
            Vector2 dir = (playerPos.position - transform.position).normalized;
            transform.up = dir;

            // Move in new direction
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else
        {
            // Normal forward movement
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, enemy.position) > deathDistance)
            Destroy(gameObject);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            PlayerAnxietyScript anxietyScript = collision.gameObject.GetComponent<PlayerAnxietyScript>();

            if (anxietyScript != null)
            {
                anxietyScript.ChangeAnxiety(anxiety);
                Debug.Log("Hit Player!");
                Destroy(gameObject);
            }
    }
}