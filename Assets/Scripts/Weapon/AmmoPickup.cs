using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] AmmoType pickUpAmmoType;
    [SerializeField] int ammoAmount;

    void Update() {
        transform.Rotate(0, 0.1f, 0);
    }
    
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            Ammo ammo = other.gameObject.GetComponent<Ammo>();
            ammo.AddAmmo(pickUpAmmoType, ammoAmount);
            Destroy(gameObject);
        }
    }
}
