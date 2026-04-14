using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerParryInputScript : MonoBehaviour
{
    [SerializeField] private ParryHitbox hitbox;
    private PlayerInput input;
    [SerializeField] private float parryCooldown = 0.2f;
    private float lastParryTime;


    private void Awake()
    {
        input = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        input.actions["Parry"].started += OnParry;
    }

    private void OnDisable()
    {
        input.actions["Parry"].started -= OnParry;
    }

    private void OnParry(InputAction.CallbackContext ctx)
    {
        TryParry();
    }

    private void TryParry()
    {

        if (Time.time < lastParryTime + parryCooldown)
            return;

        lastParryTime = Time.time;

        if (!hitbox.ValidParries.Any())
            return;

        if (!hitbox.ValidParries.Any())
            return;

        ParryScript closest = null;
        float bestDist = Mathf.Infinity;

        foreach (var p in hitbox.ValidParries)
        {
            var mb = (MonoBehaviour)p;
            float d = Vector2.Distance(transform.position, mb.transform.position);

            if (d < bestDist)
            {
                bestDist = d;
                closest = p;
            }
        }

        if (closest != null)
        {
            var mb = (MonoBehaviour)closest;
            Vector2 dir = (mb.transform.position - transform.position).normalized;
            closest.Deflect(dir);
        }
    }

    private EnemyProjectileScript FindClosestProjectile()
    {
        EnemyProjectileScript[] all = FindObjectsOfType<EnemyProjectileScript>();

        float bestDist = Mathf.Infinity;
        EnemyProjectileScript best = null;

        foreach (var p in all)
        {
            float d = Vector2.Distance(transform.position, p.transform.position);
            if (d < bestDist && d < 2f)
            {
                bestDist = d;
                best = p;
            }
        }

        return best;
    }

}
