using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSetter : MonoBehaviour
{
    [SerializeField] string volumeType;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if(volumeType == "SFX") {
            audioSource.volume = PlayerPrefs.GetFloat("sfxVolume");
        } else if(volumeType == "MUSIC") {
            audioSource.volume = PlayerPrefs.GetFloat("musicVolume");
        }
    }
    void Update()
    {
        if(volumeType == "SFX") {
            audioSource.volume = PlayerPrefs.GetFloat("sfxVolume");
        } else if(volumeType == "MUSIC") {
            audioSource.volume = PlayerPrefs.GetFloat("musicVolume");
        }
    }
}
