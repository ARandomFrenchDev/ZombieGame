using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CursorHandler : MonoBehaviour
{
    StarterAssets.StarterAssetsInputs starterAssetsInputs;
    Weapon weapon;

    void Start() {
        starterAssetsInputs = FindObjectOfType<StarterAssets.StarterAssetsInputs>();
    }

    public void SetCursorInMenuState(bool state) {
        // Time.timeScale = state ? 1 : 0;
        if(SceneManager.GetActiveScene().buildIndex > 0) {
            weapon = FindObjectOfType<Weapon>();
            weapon.canShoot = state;
        }
        starterAssetsInputs.cursorLocked = state;
        starterAssetsInputs.cursorInputForLook = state;
        starterAssetsInputs.SetCursorState(starterAssetsInputs.cursorLocked);
        Cursor.visible = !state;
    }

}
