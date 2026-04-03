using System.Collections.Generic;
using UnityEngine;

public class ParryHitbox : MonoBehaviour
{
    public readonly List<ParryScript> inside = new();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<ParryScript>(out var parry))
        {
            if (!inside.Contains(parry))
                inside.Add(parry);
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

