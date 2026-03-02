using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCourageScript : MonoBehaviour
{
    public int maxCourage;
    public int currentCourage;
    public Slider slider;

    private void Start()
    {
        currentCourage = maxCourage;
        slider.maxValue = maxCourage;
        slider.value = currentCourage;
    }
    public void ChangeCourage(int amount)
    {
        currentCourage += amount;
        slider.value = currentCourage;

        if (currentCourage <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
