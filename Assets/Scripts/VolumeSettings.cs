using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] Slider sfxVolumeSlider;
    [SerializeField] Canvas settingsCanvas;
    public float sfxVolume; 
    CursorHandler cursorHandler;

    void Start() {
        settingsCanvas.enabled = false;
        cursorHandler = FindObjectOfType<CursorHandler>();
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            cursorHandler.SetCursorInMenuState(settingsCanvas.enabled);
            settingsCanvas.enabled = !settingsCanvas.enabled;
        }
    }
    // Update is called once per frame
    public void ChangeSFXVolume() {
        sfxVolume = sfxVolumeSlider.value;
        Debug.Log(sfxVolumeSlider.value);
    }
 }
