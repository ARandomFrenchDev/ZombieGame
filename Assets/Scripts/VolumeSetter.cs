using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSetter : MonoBehaviour
{
    VolumeSettings volumeSettings;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        volumeSettings = FindObjectOfType<VolumeSettings>();
    }
    void Update()
    {
        audioSource.volume = volumeSettings.sfxVolume;
    }
}
