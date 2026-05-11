using UnityEngine;

public class BossTeleportScript : MonoBehaviour
{
    [SerializeField] BossHealthScript phases;
    [SerializeField] Transform[] teleportLocs;
    [SerializeField] float timeLeft;
    [SerializeField] float originalTime;
    [SerializeField] bool canTP;

    private void Awake()
    {
        timeLeft = originalTime;
    }
    private void Update()
    {
        if (phases.isPhase3 == true) 
        {
            if (timeLeft > 0 && phases.bossIsDead == false)
            {
                timeLeft -= Time.deltaTime;
            }
            else if (timeLeft <= 0)
            {
                timeLeft = originalTime;
                canTP = Random.value > 0.25f;
                if (canTP)
                {
                    Teleport();
                    canTP = false;
                }
            }
        }
        else if (phases.bossIsDead == true)
        {
            phases.isPhase3 = false;
            canTP = false;
            return;
        }
    }

    public void Teleport()
    {
        if (teleportLocs == null || teleportLocs.Length == 0)
        {
            Debug.LogWarning("Nuh Uh");
            return;
        }

        int index = Random.Range(0, teleportLocs.Length);
        Transform chosenSpot = teleportLocs[index];

        transform.position = chosenSpot.position;

        Debug.Log($"Teleported to point {index}");
    }
}
