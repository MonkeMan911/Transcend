using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxesDetectorScript : MonoBehaviour
{
    [Header("Separate Scripts")]
    [SerializeField] BossHealthScript phases;
    [SerializeField] BossPhase2BoxHoverScript boxes;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (phases.isPhase2)
        {
            if (boxes != null && collision.gameObject.name == "Empty Heart Box 1")
            {
                boxes.boxProgress1 += Time.deltaTime;
                Debug.Log(boxes.boxProgress1);
            }
            if (boxes != null && collision.gameObject.name == "Empty Heart Box 2")
            {
                boxes.boxProgress2 += Time.deltaTime;
                Debug.Log(boxes.boxProgress2);
            }
            if (boxes != null && collision.gameObject.name == "Empty Heart Box 3")
            {
                boxes.boxProgress3 += Time.deltaTime;
                Debug.Log(boxes.boxProgress3);
            }
            if (boxes != null && collision.gameObject.name == "Empty Heart Box 4")
            {
                boxes.boxProgress4 += Time.deltaTime;
                Debug.Log(boxes.boxProgress4);
            }
        }
    }
}
