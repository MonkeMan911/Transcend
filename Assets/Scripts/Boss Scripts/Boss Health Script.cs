using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthScript : MonoBehaviour
{
    [Header("Friend Stuff")]
    public int damageBonus = 1;
    private bool bonusApplied = false;
    [SerializeField] private BossAttackParameterScript bossParameterScript;
    [SerializeField] BossTeamUpScript bossTeamUpScript;
    public bool isFriend;

    [Header("Ints")]
    public int p1maxAcceptance;
    public int p2maxAcceptance;
    public int p3maxAcceptance;
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
        phase1Slider.maxValue = p1maxAcceptance;
        phase1Slider.value = minAcceptance;

        if (bossParameterScript == null)
            bossParameterScript = GetComponent<BossAttackParameterScript>();

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

        if (p1CurrentAcceptance >= p1maxAcceptance && isPhase1 == true)
        {
            
            phase2Slider.value = p2maxAcceptance;
            p2CurrentAcceptance = minAcceptance;
            phase2Slider.value = minAcceptance;
            p2CurrentAcceptance += amount;
            phase2Slider.value = p2CurrentAcceptance;

            phase1Slider.enabled = false;
            phase2Slider.enabled = true;
            isPhase1 = false;
            isPhase2 = true;
            if (p2CurrentAcceptance >= p2maxAcceptance && isPhase2 == true) 
            {
                phase3Slider.value = p3maxAcceptance;
                p2CurrentAcceptance = minAcceptance;
                phase3Slider.value = minAcceptance;
                p3CurrentAcceptance += amount;
                phase3Slider.value = p3CurrentAcceptance;

                phase2Slider.enabled = false;
                phase3Slider.enabled = true;
                isPhase2 = false;
                isPhase3 = true;
                if (p3CurrentAcceptance >= p3maxAcceptance && isPhase3 == true) 
                {
                    Debug.Log("Boss Vanquished");
                    if (bossTeamUpScript != null)
                    {
                        bossTeamUpScript.enabled = false;
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
