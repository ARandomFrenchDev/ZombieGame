using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] Slider sfxVolumeSlider;
    public float sfxVolume; 
    // Update is called once per frame
    public void ChangeSFXVolume() {
        sfxVolume = sfxVolumeSlider.value;
        Debug.Log(sfxVolumeSlider.value);
    }
 }
