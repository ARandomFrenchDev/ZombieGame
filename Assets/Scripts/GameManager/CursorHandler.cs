using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CursorHandler : MonoBehaviour
{
    StarterAssetsInputs starterAssetsInputs;
    FirstPersonController player;
    Weapon weapon;
    float originalSpeed;

    void Awake() {
        if(SceneManager.GetActiveScene().buildIndex > 0) { 
            player = FindObjectOfType<FirstPersonController>();
            originalSpeed = player.RotationSpeed;
            starterAssetsInputs = FindObjectOfType<StarterAssetsInputs>();
        }
    }

    public void SetCursorInMenuState(bool state) {
        if(SceneManager.GetActiveScene().buildIndex > 0) {
            player.RotationSpeed = state ? originalSpeed : 0;
            weapon = FindObjectOfType<Weapon>();
            weapon.canShoot = state;
            starterAssetsInputs.cursorLocked = state;
            starterAssetsInputs.cursorInputForLook = state;
            starterAssetsInputs.SetCursorState(starterAssetsInputs.cursorLocked);
            Cursor.visible = !state;
        }
    }

}
