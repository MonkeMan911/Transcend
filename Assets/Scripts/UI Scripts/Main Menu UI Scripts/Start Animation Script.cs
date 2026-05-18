using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimationScript : MonoBehaviour
{
    [SerializeField] Animator animator;
    private void Start()
    {
        animator = FindAnyObjectByType<Animator>();
    }

    private void Awake()
    {
        StartCoroutine(StartAnimTimer());
    }

    void StartAnim() 
    {
        animator.SetBool(("Activate"), true);
    }
    IEnumerator StartAnimTimer() 
    {
        yield return new WaitForSeconds(5);
        StartAnim();
    }
}
