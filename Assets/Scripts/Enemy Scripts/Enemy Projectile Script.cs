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
        enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        playerPos = FindClosestPlayer();
        Physics2D.IgnoreCollision(enemy.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    Transform FindClosestPlayer()
    {
        GameObject[] player = GameObject.FindGameObjectsWithTag("Player");

        Transform closest = null;
        float minDist = Mathf.Infinity;

        foreach (GameObject e in player)
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