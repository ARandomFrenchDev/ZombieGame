using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas menuCanvas;
    [SerializeField] GameObject settingsButtons;
    [SerializeField] GameObject mainButtons;
    [SerializeField] GameObject pauseButtons;
    [SerializeField] GameObject gameOverButtons;

    void Update() {
        Debug.Log("Time scale on update : " + Time.timeScale.ToString());
    }

    public void HandleDeath() {
        menuCanvas.enabled = true;
        settingsButtons.SetActive(false);
        mainButtons.SetActive(false);
        settingsButtons.SetActive(false);
        gameOverButtons.SetActive(true);
        Time.timeScale = 0;
        FindObjectOfType<CursorHandler>().SetCursorInMenuState(false);
    }
}
