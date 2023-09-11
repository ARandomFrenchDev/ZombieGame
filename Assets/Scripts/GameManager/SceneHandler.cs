using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    [SerializeField] Canvas menuCanvas;
    CursorHandler cursorHandler;
    void Start()
    {
        cursorHandler = GetComponent<CursorHandler>();
        if(SceneManager.GetActiveScene().buildIndex > 0) {
            cursorHandler.SetCursorInMenuState(true);
            menuCanvas.enabled = false;
        }
    }
    void Update()
    {
        if(menuCanvas.enabled) {
            cursorHandler.SetCursorInMenuState(false);
        }
        
    }
}
