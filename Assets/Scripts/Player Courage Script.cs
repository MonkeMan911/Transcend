using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCourageScript : MonoBehaviour
{
    public int maxCourage;
    public int currentCourage;

    public void ChangeCourage(int amount)
    {
        currentCourage += amount;

        if (currentCourage <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
