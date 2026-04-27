using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthScript : MonoBehaviour
{
    [Header("Friend Stuff")]
    public int damageBonus = 1;
    private bool bonusApplied = false;
    [SerializeField] private EnemyAttackParameterScript enemyParameterScript;
    [SerializeField] EnemiestoLoversScript enemiestoLoversScript;
    public bool isFriend;

    [Header("Ints")]
    public int maxAcceptance;
    public int minAcceptance;
    public int p1CurrentAcceptance;
    public int p2CurrentAcceptance;
    public int p3CurrentAcceptance;
    [SerializeField] private int anxiety = 1;

    [Header("Sliders")]
    public Slider phase1Slider;
    public Slider phase2Slider;
    public Slider phase3Slider;

    [Header("Bools")]
    public bool isPhase1;
    public bool isPhase2;
    public bool isPhase3;
    


    private void Start()
    {
        p1CurrentAcceptance = minAcceptance;
        phase1Slider.maxValue = maxAcceptance;
        phase1Slider.value = minAcceptance;

        if (enemyParameterScript == null)
            enemyParameterScript = GetComponent<EnemyAttackParameterScript>();

        isFriend = false;
        isPhase1 = true;
        isPhase2 = false; 
        isPhase3 = false;
    }


    private void Update()
    {
    }

    public void ChangeAcceptance(int amount)
    {
        p1CurrentAcceptance += amount;
        phase1Slider.value = p1CurrentAcceptance;

        if (p1CurrentAcceptance >= maxAcceptance && isPhase1 == true)
        {
            phase1Slider.enabled = false;
            phase2Slider.enabled = true;
            isPhase1 = false;
            if (p2CurrentAcceptance >= maxAcceptance && isPhase2 == true) 
            {
                phase2Slider.enabled = false;
                phase3Slider.enabled = true;
                isPhase2 = false;
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
