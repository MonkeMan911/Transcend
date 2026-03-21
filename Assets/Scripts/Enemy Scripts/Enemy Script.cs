using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    [Header("Friend Stuff")]
    public int damageBonus = 1;
    private bool bonusApplied = false;
    [SerializeField] private EnemyAttackParameterScript enemyParameterScript;
    [SerializeField] EnemiestoLoversScript enemiestoLoversScript;
    public bool isFriend;

    [Header("Health Bar")]
    [SerializeField] private Camera acceptanceBarCamera;
    [SerializeField] private Transform enemyBarPos;
    [SerializeField] private Vector3 offset;
    public int maxAcceptance;
    public int minAcceptance;
    public int currentAcceptance;
    public Slider acceptanceSlider;
    [SerializeField] private int anxiety = 1;


    private void Start()
    {
        currentAcceptance = minAcceptance;
        acceptanceSlider.maxValue = maxAcceptance;
        acceptanceSlider.value = minAcceptance;

        if (enemyParameterScript == null)
            enemyParameterScript = GetComponent<EnemyAttackParameterScript>();

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

        if (currentAcceptance >= maxAcceptance && !bonusApplied)
        {
            Debug.Log("Switchin Sides");

            if (enemyParameterScript != null)
            {
                enemyParameterScript.enabled = false;
                isFriend = true;
                gameObject.tag = "Friend";

                PlayerDamageManager dmg = FindObjectOfType<PlayerDamageManager>();
                if (dmg != null)
                {
                    dmg.AddFriendBonus(damageBonus);
                }

                bonusApplied = true;
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
