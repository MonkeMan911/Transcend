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

    [Header("Misc")]
    [SerializeField] private GameObject manager;


    private void Start()
    {
        //phase 1 slider
        p1CurrentAcceptance = minAcceptance;
        phase1Slider.maxValue = p1maxAcceptance;
        phase1Slider.value = minAcceptance;
        //phase 2 slider
        p2CurrentAcceptance = minAcceptance;
        phase2Slider.maxValue = p2maxAcceptance;
        phase2Slider.value = minAcceptance;
        //phase 3 slider
        p3CurrentAcceptance = minAcceptance;
        phase3Slider.maxValue = p3maxAcceptance;
        phase3Slider.value = minAcceptance;

        if (bossParameterScript == null)
            bossParameterScript = GetComponent<BossAttackParameterScript>();

        isFriend = false;
        isPhase1 = true;
        isPhase2 = false; 
        isPhase3 = false;
        StartPhaseOne(isPhase1 = true);
    }


    private void Update()
    {
        if (!isPhase1) 
        {
            phase1Slider.enabled = false;
            phase1Slider.gameObject.SetActive(false);
        }
        if (!isPhase2) 
        {
            phase2Slider.enabled = false;
            phase2Slider.gameObject.SetActive(false);
        }
        if (!isPhase3) 
        {
            phase3Slider.enabled = false;
            phase3Slider.gameObject.SetActive(false);
        }
    }

    public void ChangeAcceptance(params int[] amounts)
    {
        
        // Phase 1
        if (isPhase1 && amounts.Length > 0)
        {
            p1CurrentAcceptance += amounts[0];
            phase1Slider.value = p1CurrentAcceptance;

            if (p1CurrentAcceptance >= p1maxAcceptance)
            {
                StartPhaseTwo(isPhase2 = true);
            }
        }

        // Phase 2
        if (isPhase2 && amounts.Length > 1)
        {
            p2CurrentAcceptance += amounts[1];
            phase2Slider.value = p2CurrentAcceptance;

            if (p2CurrentAcceptance >= p2maxAcceptance)
            {
                StartPhaseThree(isPhase3 = true);
            }
        }

        // Phase 3
        if (isPhase3 && amounts.Length > 2)
        {
            p3CurrentAcceptance += amounts[2];
            phase3Slider.value = p3CurrentAcceptance;

            if (p3CurrentAcceptance >= p3maxAcceptance)
            {
                BossToLover();
                manager.GetComponent<ChangeMaterialScript>().MatterialSwapper();
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

    public void StartPhaseOne(bool isPhase1) 
    {
        phase1Slider.enabled = true;
        phase1Slider.gameObject.SetActive(true);
        isPhase1 = true;
        isPhase2 = false;
        isPhase3 = false;
    } 
    public void StartPhaseTwo(bool isPhase2) 
    {
        phase2Slider.enabled = true;
        phase2Slider.gameObject.SetActive(true);
        isPhase2 = true;
        isPhase1 = false;
        isPhase3 = false;
    } 
    public void StartPhaseThree(bool isPhase3) 
    {
        phase3Slider.enabled = true;
        phase3Slider.gameObject.SetActive(true);
        isPhase3 = true;
        isPhase1 = false;
        isPhase2 = false;
    }
    private void BossToLover()
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
            Debug.LogWarning("BossAttackParameterScript reference is missing!");
        }
    }

}
