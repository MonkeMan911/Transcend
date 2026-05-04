using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectileScript : MonoBehaviour, ParryScript
{
    [SerializeField] private AnimationCurve speedCurve;
    public float proSpeed = 10f;
    public float deathDistance = 20f;
    public float homingDistance = 10f;
    [SerializeField] private int anxiety;

    public Transform playerPos;
    private Transform boss;

    [SerializeField] private Transform proj;

    [field: SerializeField]
    public float returnSpeed { get; set; }
    public bool IsParrying { get; set; }

    private float parrySpeed, time;

    private Collider2D projCol;
    private Collider2D bossCol;

    private Rigidbody2D projRB;

    void Start()
    {
        IsParrying = false;
        time = 0f;

        boss = transform.parent;

        projCol = GetComponent<Collider2D>();
        bossCol = boss != null ? boss.GetComponent<Collider2D>() : null;

        SetIgnoreEnemyCollision(true);

        projRB = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (IsParrying)
        {
            parrySpeed = speedCurve.Evaluate(time);
            time += Time.fixedDeltaTime;
            projRB.velocity = transform.up * returnSpeed * parrySpeed;
            return;
        }

        Vector2 moveDir = transform.up;
        projRB.velocity = moveDir * proSpeed;
    }

    public void SetIgnoreEnemyCollision(bool shouldIgnore)
    {
        if (bossCol == null || projCol == null)
        {
            Debug.LogWarning($"{name}: Missing collider reference for collision toggle.");
            return;
        }

        Physics2D.IgnoreCollision(bossCol, projCol, shouldIgnore);
    }

    void Update()
    {
        if (playerPos == null)
        {
            transform.Translate(Vector2.up * proSpeed * Time.deltaTime);
            return;
        }

        float distanceToPlayer = Vector2.Distance(transform.position, playerPos.position);

        if (distanceToPlayer < homingDistance)
        {
            Vector2 dir = (playerPos.position - transform.position).normalized;
            transform.up = dir;
        }

        transform.Translate(Vector2.up * proSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, boss.position) > deathDistance)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerAnxietyScript anxietyScript = collision.gameObject.GetComponent<PlayerAnxietyScript>();

        if (anxietyScript != null)
        {
            anxietyScript.ChangeAnxiety(anxiety);
            Destroy(gameObject);
        }
        else
        {
            BossHealthScript bossScript = collision.collider.GetComponentInParent<BossHealthScript>();
            if (bossScript != null && !bossScript.isFriend)
            {
                PlayerDamageManager dmg = FindObjectOfType<PlayerDamageManager>();
                int finalDamage = dmg != null ? dmg.currentDamage : 1;

                bossScript.ChangeAcceptance(finalDamage);
                Destroy(gameObject);
            }
        }
    }

    public void Deflect(Vector2 direction)
    {
        if (IsParrying)
            return;

        IsParrying = true;
        time = 0f;

        SetIgnoreEnemyCollision(false);

        transform.up = direction;

        projRB.velocity = transform.up * returnSpeed;

        gameObject.layer = LayerMask.NameToLayer("ParriedProjectile");
    }
}
