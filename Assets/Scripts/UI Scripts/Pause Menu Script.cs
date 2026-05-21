using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField] PanelOpenCloseScript panelOpenCloseScript;
    [SerializeField] 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) 
        {
            PauseGame();
        }
    }

    public void PauseGame() 
    {
        panelOpenCloseScript.OpenPanel();
        Time.timeScale = 0f;
    }
    public void UnPauseGame() 
    {
        Time.timeScale = 1f;
    }
}
