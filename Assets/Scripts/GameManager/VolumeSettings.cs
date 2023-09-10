using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] Slider sfxVolumeSlider;
    [SerializeField] Slider musicVolumeSlider;

    void Start() {
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        musicVolumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        Debug.Log(PlayerPrefs.GetFloat("musicVolume"));
        // settingsCanvas.enabled = false;
    }

    public void ChangeSFXVolume() {
        PlayerPrefs.SetFloat("sfxVolume", sfxVolumeSlider.value);
        Debug.Log(PlayerPrefs.GetFloat("sfxVolume"));
        PlayerPrefs.Save();
    }
    public void ChangeMusicVolume() {
        PlayerPrefs.SetFloat("musicVolume", musicVolumeSlider.value);
        Debug.Log(PlayerPrefs.GetFloat("musicVolume"));
        PlayerPrefs.Save();
    }
 }
