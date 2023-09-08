using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Canvas mainMenuSettings;

    void Start() {
        mainMenuSettings.enabled = false;
    }

    public void PlayButtonClick() {
        SceneManager.LoadScene(1);
    }

    public void SettingsButtonClick() {
        mainMenuSettings.enabled = true;
        enabled = false;
    }

    public void QuitGameButtonClick() {
        Application.Quit();
    }
}
