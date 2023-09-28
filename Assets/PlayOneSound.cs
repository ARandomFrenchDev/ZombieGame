using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOneSound : MonoBehaviour
{
    [SerializeField] AudioClip audioClip;

    public void HandlePlayOneShot() {
        GetComponent<AudioSource>().PlayOneShot(audioClip);
    }

}
