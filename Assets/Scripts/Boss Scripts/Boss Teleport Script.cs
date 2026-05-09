using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossTeleportScript : MonoBehaviour
{
    [SerializeField] Transform[] teleportLocs;
    public void Start()
    {
        teleportLocs = new Transform[teleportLocs.Length];
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Teleport();
        }
    }

    public void Teleport()
    {
        Vector2 randomPos = new Vector2(Random.Range(0, teleportLocs.Length), Random.Range(0, teleportLocs.Length));
        transform.position = randomPos;
    }
}
