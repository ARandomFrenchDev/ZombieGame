using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseEvent : MonoBehaviour
{
    [SerializeField] GameObject house;
    [SerializeField] AudioClip keySound;
    private bool hasBeenActivated = false ;

    void Start() {
        house.SetActive(false);
    }
    
    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && !hasBeenActivated) {
            house.SetActive(true);
            other.gameObject.GetComponent<AudioSource>().PlayOneShot(keySound);
            hasBeenActivated = true;
        }
    }
}
