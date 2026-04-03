using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerParryInputScript : MonoBehaviour
{
    [SerializeField] private ParryHitbox hitbox;
    private PlayerInput input;

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        input.actions["Parry"].performed += OnParry;
    }

    private void OnDisable()
    {
        input.actions["Parry"].performed -= OnParry;
    }

    private void OnParry(InputAction.CallbackContext ctx)
    {
        TryParry();
    }

    private void TryParry()
    {
        if (hitbox.inside.Count == 0)
            return;

        ParryScript closest = null;
        float bestDist = Mathf.Infinity;

        foreach (var p in hitbox.inside)
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
