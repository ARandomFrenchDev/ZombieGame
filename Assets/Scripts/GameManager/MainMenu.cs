using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Canvas menuCanvas;
    [SerializeField] GameObject mainButtons;
    [SerializeField] GameObject settingsButtons;
    [SerializeField] GameObject pauseButtons;
    [SerializeField] GameObject gameOverButtons;

    void Start() {
        settingsButtons.SetActive(false);
        pauseButtons.SetActive(false);
        gameOverButtons.SetActive(false);
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex != 0 && menuCanvas.enabled == false) {
            menuCanvas.enabled = true;
            pauseButtons.SetActive(true);
            mainButtons.SetActive(false);
            settingsButtons.SetActive(false);
            gameOverButtons.SetActive(false);
            
            Time.timeScale = 0;
            GetComponent<CursorHandler>().SetCursorInMenuState(false);
        }
    }

    public void GoBackToGameClick() {
        menuCanvas.enabled = false;
        GetComponent<CursorHandler>().SetCursorInMenuState(true);
        Time.timeScale = 1;
    }

    public void GoBackToMainMenuClick() {
        SceneManager.LoadScene(0);
    }

    public void PlayButtonClick() {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void MenuToSettingsButtonClick() {
        settingsButtons.SetActive(true);
        if(SceneManager.GetActiveScene().buildIndex != 0) {
            pauseButtons.SetActive(false);
        } else {
            mainButtons.SetActive(false);
        }
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
