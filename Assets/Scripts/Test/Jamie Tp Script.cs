using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JamieTpScript : MonoBehaviour
{
    [SerializeField] Transform Tpposition;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Box")) 
        {
            SwitchToNextStage();   
        }
    }

    public void SwitchToNextStage() 
    {
        transform.position = Tpposition.position;
    }
}
