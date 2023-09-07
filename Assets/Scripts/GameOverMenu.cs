using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    CursorHandler cursorHandler;

    private void Start() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        cursorHandler = player.GetComponent<CursorHandler>();
    }   

    public void ReloadLevel() {
        cursorHandler.SetCursorInMenuState(true);
        Debug.Log("reloading level");
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }

    public void QuitLevel() {
        Application.Quit();
    }

}
