using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cinemachine;

public class PlayerCourageScript : MonoBehaviour
{
    public int maxCourage;
    public int currentCourage;
    public Slider slider;
    private CinemachineImpulseSource impulseSource;

    private void Start()
    {
        currentCourage = maxCourage;
        slider.maxValue = maxCourage;
        slider.value = currentCourage;
        impulseSource = GetComponent<CinemachineImpulseSource>();

    }

    public void ChangeCourage(int amount)
    {
        CameraShakeScript.instance.CameraShake(impulseSource);
        currentCourage += amount;
        slider.value = currentCourage;

        if (currentCourage <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
