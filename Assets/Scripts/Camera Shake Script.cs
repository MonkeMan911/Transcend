using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeScript : MonoBehaviour
{
    public bool start = false;
    public AnimationCurve curve;
    public float duration = 1f;
    void Update()
    {
        if (start) 
        {
            start = false;
            StartCoroutine(Shaking());
        }
    }
    IEnumerator Shaking() 
    {
        Vector2 startPos = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration) 
        {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / duration);
            transform.position = startPos + Random.insideUnitCircle * strength;
            yield return null;
        }
        transform.position = startPos;
    }
}
