using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorHandler : MonoBehaviour
{
    StarterAssets.StarterAssetsInputs starterAssetsInputs;

    void Start() {
        starterAssetsInputs = GetComponent<StarterAssets.StarterAssetsInputs>();

    }

    public void SetCursorInMenuState(bool state) {
        Time.timeScale = 0; 
        starterAssetsInputs.cursorLocked = state;
        starterAssetsInputs.cursorInputForLook = state;
        starterAssetsInputs.SetCursorState(starterAssetsInputs.cursorLocked);
        Cursor.visible = !state;
    }

}
