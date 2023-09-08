using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] Slider sfxVolumeSlider;
    [SerializeField] Slider musicVolumeSlider;
    [SerializeField] Canvas settingsCanvas;
    public float musicVolume = 1f; 
    public float sfxVolume = 1f; 
    CursorHandler cursorHandler;

    void Start() {
        musicVolumeSlider.value = musicVolume;
        sfxVolumeSlider.value = sfxVolume;
        settingsCanvas.enabled = false;
        cursorHandler = FindObjectOfType<CursorHandler>();
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name != "Main Menu") {
            cursorHandler.SetCursorInMenuState(settingsCanvas.enabled);
            settingsCanvas.enabled = !settingsCanvas.enabled;
        }
    }
    public void ChangeSFXVolume() {
        sfxVolume = sfxVolumeSlider.value;
    }
    public void ChangeMusicVolume() {
        musicVolume = musicVolumeSlider.value;
    }
 }
