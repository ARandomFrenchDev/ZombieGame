using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] float speedFlash = 5f;
    [SerializeField] Light mainSpotLight;

    void Update() {
        HandleTime();
    }

    private void HandleTime() {
        mainSpotLight.intensity -= speedFlash * Time.deltaTime;
    }

    public void ActivateFlashlight() {
        mainSpotLight.intensity = 60;
    }
 }
