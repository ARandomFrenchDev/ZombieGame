using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    CursorHandler cursorHandler;

    private void Start() {
        cursorHandler = GetComponent<CursorHandler>();
    }   

    public void ReloadLevel() {
        cursorHandler.SetCursorInMenuState(true);
        SceneManager.LoadScene(1);
        Time.timeScale = 1.0f;
    }

    public void QuitLevel() {
        SceneManager.LoadScene(0);
    }

}
