using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Canvas mainMenuCanvas;
    [SerializeField] GameObject settingsButtons;
    [SerializeField] GameObject mainButtons;
    CursorHandler cursorHandler;

    void Start() {
        settingsButtons.SetActive(false);
        cursorHandler = GetComponent<CursorHandler>();
    }

    void Update() {
        if(SceneManager.GetActiveScene().name != "Main Menu") {
            mainMenuCanvas.enabled = false;
            cursorHandler.SetCursorInMenuState(true);
        }
        
        if(Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name != "Main Menu" && mainMenuCanvas.enabled == false) {
            cursorHandler.SetCursorInMenuState(false);
            mainMenuCanvas.enabled = true;
        }
    }

    public void GoBackToGameClick() {
        cursorHandler.SetCursorInMenuState(true);
        mainMenuCanvas.enabled = false;
    }

    public void PlayButtonClick() {
        SceneManager.LoadScene(1);
    }

    public void SettingsButtonClick() {
        settingsButtons.SetActive(true);
        mainButtons.SetActive(false);
    }

    public void MainMenuButtonClick() {
        settingsButtons.SetActive(false);
        mainButtons.SetActive(true);
    }

    public void QuitGameButtonClick() {
        Application.Quit();
    }
}
