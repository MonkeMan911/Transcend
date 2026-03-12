using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private Camera acceptanceBarCamera;
    [SerializeField] private Transform enemyBarPos;
    [SerializeField] private Vector3 offset;
    public int maxAcceptance;
    public int minAcceptance;
    public int currentAcceptance;
    public Slider acceptanceSlider;
    [SerializeField] private int anxiety = 1;
    [SerializeField] private EnemyAttackParameterScript enemyParameterScript;
    public bool isFriend;

    private void Start()
    {
        currentAcceptance = minAcceptance;
        acceptanceSlider.maxValue = maxAcceptance;
        acceptanceSlider.value = minAcceptance;
        GetComponent<Collider2D>();
        isFriend = false;
    }

    private void Update()
    {
        transform.rotation = acceptanceBarCamera.transform.rotation;
        transform.position = enemyBarPos.position + offset;
    }

    public void ChangeAcceptance(int amount)
    {
        currentAcceptance += amount;
        acceptanceSlider.value = currentAcceptance;

        if (currentAcceptance >= maxAcceptance)
        {
            Debug.Log("Switchin Sides");


            if (enemyParameterScript != null)
            {
                enemyParameterScript.enabled = false;
                isFriend = true;
            }
            else
            {
                Debug.LogWarning("EnemyAttackParameterScript reference is missing!");
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerAnxietyScript anxietyScript = collision.gameObject.GetComponent<PlayerAnxietyScript>();

        if (anxietyScript != null)
        {
            anxietyScript.ChangeAnxiety(anxiety);
        }
    }

}
