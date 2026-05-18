using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpenCloseScript : MonoBehaviour
{
    public GameObject panel;
    void Start()
    {
        panel.GetComponent<GameObject>();
    }

    public void OpenPanel() 
    {
        if (panel != null)
        {
            panel.SetActive(!panel.activeSelf);
        }
    }
}
