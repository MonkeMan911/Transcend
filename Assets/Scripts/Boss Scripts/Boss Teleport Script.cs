using UnityEngine;

public class BossTeleportScript : MonoBehaviour
{
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
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
        else if (timeLeft <= 0)
        {
            timeLeft = originalTime;
            canTP = Random.value > 0.25f;
            if (canTP == true) 
            {
                Teleport();
                canTP = false;
            }
        }
    }

    public void Teleport()
    {
        if (teleportLocs == null || teleportLocs.Length == 0)
        {
            Debug.LogWarning("No teleport locations assigned!");
            return;
        }

        int index = Random.Range(0, teleportLocs.Length);
        Transform chosenSpot = teleportLocs[index];

        transform.position = chosenSpot.position;

        Debug.Log($"Teleported to point {index}");
    }
}
