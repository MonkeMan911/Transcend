using System.Collections.Generic;
using UnityEngine;

public class ParryHitbox : MonoBehaviour
{
    private readonly Dictionary<ParryScript, float> inside = new();
    private const float parryGraceTime = 0.1f;

    public IEnumerable<ParryScript> ValidParries
    {
        get
        {
            foreach (var kvp in inside)
            {
                if (Time.time >= kvp.Value + parryGraceTime)
                    yield return kvp.Key;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<ParryScript>(out var parry))
        {
            if (!inside.ContainsKey(parry))
                inside.Add(parry, Time.time);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<ParryScript>(out var parry))
        {
            inside.Remove(parry);
        }

    }

}