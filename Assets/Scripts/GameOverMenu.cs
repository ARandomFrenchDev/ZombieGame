using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    // StarterAssets.StarterAssetsInputs starterAssetsInputs;

    public void ReloadLevel() {
        // starterAssetsInputs.cursorLocked = true;
        // starterAssetsInputs.cursorInputForLook = true;
 
        // starterAssetsInputs.SetCursorState(starterAssetsInputs.cursorLocked);
        Debug.Log("reloading level");
        SceneManager.LoadScene(0);
    }

    public void QuitLevel() {
        Application.Quit();
    }

}
