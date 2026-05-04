using UnityEngine;

public class BossFightProjectileScript : MonoBehaviour
{
    public float speed = 10f;
    public float deathDistance = 20f;
    public float homingDistance = 10f;
    [SerializeField] private int acceptanceNum;
    [SerializeField] private BossHealthScript bossHealth;
    public Transform bossPos;
    private Transform player;
    [SerializeField] private Transform proj;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        bossPos = FindClosestEnemy();
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    Transform FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        Transform closest = null;
        float minDist = Mathf.Infinity;

        foreach (GameObject e in enemies)
        {
            BossHealthScript bossScript = e.GetComponent<BossHealthScript>();

            // Skip if this enemy is now a friend
            if (bossScript != null && bossScript.isFriend)
                continue;

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
        if (bossPos == null)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
            return;
        }

        float distanceToBoss = Vector2.Distance(transform.position, bossPos.position);

        // Homing behavior
        if (distanceToBoss < homingDistance)
        {
            // Rotate toward enemy
            Vector2 dir = (bossPos.position - transform.position).normalized;
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
        BossHealthScript bossScript = collision.collider.GetComponentInParent<BossHealthScript>();

        if (bossScript != null && !bossScript.isFriend)
        {
            PlayerDamageManager dmg = FindObjectOfType<PlayerDamageManager>();
            int finalDamage = dmg != null ? dmg.currentDamage : 1;

            bossScript.ChangeAcceptance(3, 2, 1 & finalDamage);

            Debug.Log("Hit Enemy for " + finalDamage);
            Destroy(gameObject);
        }
    }
}