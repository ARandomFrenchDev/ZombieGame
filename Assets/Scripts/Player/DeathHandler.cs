using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas menuCanvas;
    [SerializeField] GameObject settingsButtons;
    [SerializeField] GameObject mainButtons;
    [SerializeField] GameObject pauseButtons;
    [SerializeField] GameObject gameOverButtons;

    CursorHandler cursorHandler;

    void Awake() {
        cursorHandler = FindObjectOfType<CursorHandler>();
    }

    public void HandleDeath() {
        if(SceneManager.GetActiveScene().buildIndex != 6) {
            menuCanvas.enabled = true;
            settingsButtons.SetActive(false);
            mainButtons.SetActive(false);
            settingsButtons.SetActive(false);
            gameOverButtons.SetActive(true);
            Time.timeScale = 0;
            cursorHandler.SetCursorInMenuState(false);
        } else {
            cursorHandler.SetCursorInMenuState(false);
            SceneManager.LoadScene(0);
        }
    }
}
