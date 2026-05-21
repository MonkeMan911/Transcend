using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControlScript : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float volumeSliderNum;
    [SerializeField] private Slider volumeSlider;

    void Start()
    {
        volumeSlider.GetComponent<Slider>();
        audioSource.GetComponent<AudioSource>().volume = volumeSliderNum;
    }

    void Update()
    {
        volumeSliderNum = volumeSlider.value;
        audioSource.volume = volumeSliderNum;
        Debug.Log(PlayerPrefs.GetFloat("Volume Prefs", volumeSliderNum));
    }
    
    public void SaveVolumeControls () 
    {
        PlayerPrefs.SetFloat("Volume Prefs", volumeSliderNum);
        PlayerPrefs.Save();
    }
    public void LoadVolumeControls () 
    {
        PlayerPrefs.GetFloat("Volume Prefs", volumeSliderNum);
    }
}
