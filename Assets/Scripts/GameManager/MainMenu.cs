using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Canvas menuCanvas;
    [SerializeField] GameObject settingsButtons;
    [SerializeField] GameObject mainButtons;
    [SerializeField] GameObject pauseButtons;
    [SerializeField] GameObject gameOverButtons;
    CursorHandler cursorHandler;

    void Start() {
        settingsButtons.SetActive(false);
        pauseButtons.SetActive(false);
        gameOverButtons.SetActive(false);
        cursorHandler = GetComponent<CursorHandler>();
    }

    void Update() {
        if(SceneManager.GetActiveScene().buildIndex != 0) {
            menuCanvas.enabled = false;
            cursorHandler.SetCursorInMenuState(true);
        }
        
        if(Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex != 0 && menuCanvas.enabled == false) {
            menuCanvas.enabled = true;
            pauseButtons.SetActive(true);
            mainButtons.SetActive(false);
            settingsButtons.SetActive(false);
            gameOverButtons.SetActive(false);
            
            Time.timeScale = 0;
            // cursorHandler.SetCursorInMenuState(false);
        }
    }

    public void GoBackToGameClick() {
        cursorHandler.SetCursorInMenuState(true);
        menuCanvas.enabled = false;
    }

    public void GoBackToMainMenuClick() {
        SceneManager.LoadScene(0);
    }

    public void PlayButtonClick() {
        SceneManager.LoadScene(1);
    }

    public void MenuToSettingsButtonClick() {
        settingsButtons.SetActive(true);
        mainButtons.SetActive(false);
    }

    public void SettingsToMenuButtonClick() {
        settingsButtons.SetActive(false);
        if(SceneManager.GetActiveScene().buildIndex != 0) {
            pauseButtons.SetActive(true);
        } else {
            mainButtons.SetActive(true);
        }
    }

    public void QuitGameButtonClick() {
        Application.Quit();
    }
}
