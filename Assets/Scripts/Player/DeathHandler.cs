using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;

    private void Start() {
        gameOverCanvas.enabled = false;
    }   

    void Update() {
        Debug.Log("Time scale on update : " + Time.timeScale.ToString());
    }

    public void HandleDeath() {
        gameOverCanvas.enabled = true;
        Time.timeScale = 0;
        FindObjectOfType<CursorHandler>().SetCursorInMenuState(false);
    }
}
