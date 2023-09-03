using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    void Update() {
        transform.Rotate(0, 0.1f, 0);
    }
    
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            FindObjectOfType<Flashlight>().ActivateFlashlight();
            Destroy(gameObject);
        }
    }
}
