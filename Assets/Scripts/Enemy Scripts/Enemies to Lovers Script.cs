using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiestoLoversScript : MonoBehaviour
{
    [SerializeField] EnemyScript enemyScript;
    public Transform Friend;
    [SerializeField] Vector3 offset;
    void Start()
    {
        
    }

    void Update()
    {
        if (enemyScript.isFriend == true) 
        {
            Friend.SetParent(this.transform);
            Friend.position = this.transform.position + offset;
        }
    }
}
