using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControlScript : MonoBehaviour
{
    [SerializeField] private float volumeSliderNum;
    [SerializeField] private Slider volumeSlider;

    void Start()
    {
        volumeSlider.GetComponent<Slider>();
    }

    void Update()
    {
        volumeSliderNum = volumeSlider.value;
    }
    
    public void SaveVolumeControls () 
    {
        PlayerPrefs.SetFloat("Volume Prefs", volumeSliderNum);
    }
    public void LoadVolumeControls () 
    {
        PlayerPrefs.GetFloat("Volume Prefs", volumeSliderNum);
    }
}
