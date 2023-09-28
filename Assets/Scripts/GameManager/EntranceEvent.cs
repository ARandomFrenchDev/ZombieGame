using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceEvent : MonoBehaviour
{
    [SerializeField] GameObject wall;
    [SerializeField] AudioClip wallClosing;
    [SerializeField] AudioSource ambiantMusic;
    private bool isClosed = false;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player" && !isClosed) {
            wall.transform.position = new Vector3(wall.transform.position.x, 13, wall.transform.position.z);
            AudioSource audioSource = other.gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(wallClosing);
            ambiantMusic.Play();
            isClosed = true;
        }
    }
}
