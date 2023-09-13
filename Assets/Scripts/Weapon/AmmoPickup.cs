using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] public AmmoType pickUpAmmoType;
    [SerializeField] public int ammoAmount;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip reloadSound;

    void Awake() {
        audioSource = FindObjectOfType<WeaponSway>().GetComponent<AudioSource>();
    }

    void Update() {
        transform.Rotate(0, 0.1f, 0);
    }
    
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            Ammo ammo = other.gameObject.GetComponent<Ammo>();
            ammo.AddAmmo(pickUpAmmoType, ammoAmount);
            audioSource.PlayOneShot(reloadSound);
            Destroy(gameObject);
        }
    }
}
