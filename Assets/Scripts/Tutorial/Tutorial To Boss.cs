using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialToBoss : MonoBehaviour
{
    [SerializeField] EnemiestoLoversScript enemiestoLoversScript;
    [SerializeField] float enemiesNeeded;

    // Update is called once per frame
    void Update()
    {
        if (enemiestoLoversScript.enemiesKilled >= enemiesNeeded) 
        {
            SceneManager.LoadScene("Transcend Boss Fight");
        }
    }
}
