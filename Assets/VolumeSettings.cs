using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] float sfxVolume; 
    // Update is called once per frame
    public void ChangeSFXVolume(AudioSource audioSource) {
        audioSource.volume = sfxVolume;
    }
 }
