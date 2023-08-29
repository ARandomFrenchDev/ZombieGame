using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    StarterAssets.StarterAssetsInputs starterAssetsInputs;

    private void Start() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        starterAssetsInputs = player.GetComponent<StarterAssets.StarterAssetsInputs>();
    }   

    public void ReloadLevel() {
        starterAssetsInputs.cursorLocked = true;
        starterAssetsInputs.cursorInputForLook = true;
        starterAssetsInputs.SetCursorState(starterAssetsInputs.cursorLocked);
        Debug.Log("reloading level");
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
        Cursor.visible = false;
    }

    public void QuitLevel() {
        Application.Quit();
    }

}
