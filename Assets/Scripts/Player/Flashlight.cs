using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] float timeFlash = 45f;
    [SerializeField] Light mainSpotLight;

    void Update() {
        StartCoroutine(HandleTime(timeFlash));
    }

    IEnumerator HandleTime(float timeFlash) {
        yield return new WaitForSeconds(timeFlash);
        mainSpotLight.enabled = false;
    }

    void ActivateFlashlight() {
        mainSpotLight.enabled = true;
    }
 }
