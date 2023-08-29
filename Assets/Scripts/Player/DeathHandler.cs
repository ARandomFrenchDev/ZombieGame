using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{

    StarterAssets.StarterAssetsInputs starterAssetsInputs;
    [SerializeField] Canvas gameOverCanvas;

    private void Start() {
        gameOverCanvas.enabled = false;
        
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        starterAssetsInputs = player.GetComponent<StarterAssets.StarterAssetsInputs>();
    }   

    public void HandleDeath() {
        gameOverCanvas.enabled = true;
        Time.timeScale = 0; 
        starterAssetsInputs.cursorLocked = false;
        starterAssetsInputs.cursorInputForLook = false;
        starterAssetsInputs.SetCursorState(starterAssetsInputs.cursorLocked);
        Cursor.visible = true;

    }
}
