using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoTextScript : MonoBehaviour
{
    [SerializeField] public PlayerScript pScript;
    [SerializeField] public TextMeshProUGUI ammoText;
    [SerializeField] private TextMeshProUGUI reloadText;
    [SerializeField] private float currentTime;
    void Start()
    {
        currentTime = pScript.weaponCooldown;
        UpdateAmmoText();
    }

    void Update()
    {
        UpdateAmmoText();
        if (pScript.isReloading == true) 
        {
            currentTime -= Time.deltaTime;
            if (currentTime < 0) 
            {
                currentTime = 0;
            }
        }
        if (pScript.isReloading == false) 
        {
            currentTime = pScript.weaponCooldown;
        }
    }
    public void UpdateAmmoText()
    {
        ammoText.text = $"{pScript.currentClip} / {pScript.maxClipSize}";
        reloadText.text = currentTime.ToString("F1");
    }
}
