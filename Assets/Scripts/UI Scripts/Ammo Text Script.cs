using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoTextScript : MonoBehaviour
{
    [SerializeField] public PlayerScript pScript;
    [SerializeField] public TextMeshProUGUI ammoText;
    [SerializeField] private TextMeshProUGUI reloadText;
    void Start()
    {
        UpdateAmmoText();
    }

    void Update()
    {
        UpdateAmmoText();
    }
    public void UpdateAmmoText()
    {
        ammoText.text = $"{pScript.currentClip} / {pScript.maxClipSize}";
        reloadText.text = $"{pScript.weaponCooldown}";
    }
}
