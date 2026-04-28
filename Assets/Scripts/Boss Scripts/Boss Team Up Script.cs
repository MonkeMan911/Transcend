using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTeamUpScript : MonoBehaviour
{
    [Header("Friend Settings")]
    public Vector3 baseOffset = new Vector3(1f, 0f, 0f);
    public float spacing = 1.5f;

    private List<BossHealthScript> friends = new List<BossHealthScript>();

    void Update()
    {
        BossHealthScript[] allEnemies = FindObjectsOfType<BossHealthScript>();

        foreach (BossHealthScript enemy in allEnemies)
        {
            if (enemy.isFriend && !friends.Contains(enemy))
            {
                AddFriend(enemy);
            }
        }

        UpdateFriendPositions();
    }

    void AddFriend(BossHealthScript enemy)
    {
        friends.Add(enemy);

        enemy.transform.SetParent(transform);

        Debug.Log("Added new friend: " + enemy.name);
    }

    void UpdateFriendPositions()
    {
        for (int i = 0; i < friends.Count; i++)
        {
            Vector3 offset = baseOffset + new Vector3(i * spacing, 0, 0);
            friends[i].transform.localPosition = offset;
        }
    }
}
