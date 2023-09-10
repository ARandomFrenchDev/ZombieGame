using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorHandler : MonoBehaviour
{
    StarterAssets.StarterAssetsInputs starterAssetsInputs;
    Weapon weapon;

    void Start() {
        starterAssetsInputs = FindObjectOfType<StarterAssets.StarterAssetsInputs>();
        weapon = FindObjectOfType<Weapon>();

    }

    public void SetCursorInMenuState(bool state) {
        Time.timeScale = state ? 1 : 0;
        weapon.canShoot = state;
        starterAssetsInputs.cursorLocked = state;
        starterAssetsInputs.cursorInputForLook = state;
        starterAssetsInputs.SetCursorState(starterAssetsInputs.cursorLocked);
        Cursor.visible = !state;
    }

}
