using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskHandler : MonoBehaviour
{
    [SerializeField] TMP_Text taskText;
    [SerializeField] Canvas transitionCanvas;
    [SerializeField] float gettingOutTimer = 60f;
    [SerializeField] float lastTimer = 25f;
    CursorHandler cursorHandler;
    public float taskScorePointsTotal = 0f;
    public int activeWeaponScene;
    public bool canSwitchWeapon = true;
    void Awake() {
        cursorHandler = GetComponent<CursorHandler>();
    }
    void Update() {
        HandleTask();
    }
    void HandleTask() {
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        if(currentScene == 1) {
            taskText.text = "DÉTRUIS LES CIBLES :)";
            activeWeaponScene = 1;
            canSwitchWeapon = false;
        } else if(currentScene == 2) {
            taskText.text = "ENQUETE.";
            activeWeaponScene = 3;
            canSwitchWeapon = false;
        } else if(currentScene == 3) {
            activeWeaponScene = 2;
            canSwitchWeapon = false;
            taskText.color = Color.red;
            Level3Countdown();
        } else if(currentScene == 4) {
            activeWeaponScene = 0;
            canSwitchWeapon = true;
            taskText.text = "Va voir la cabane.";
        } else if(currentScene == 5) {
            activeWeaponScene = 0;
            canSwitchWeapon = false;
            taskText.text = "... sors.";
        } else if(currentScene == 6) {
            activeWeaponScene = 1;
            canSwitchWeapon = true;
            taskText.text = "au revoir.";
            Level6Countdown();
        } 
    }
    private void Level3Countdown(){
        gettingOutTimer = gettingOutTimer - Time.deltaTime;
        if(gettingOutTimer < 0.5f) {
            DeathHandler player = FindObjectOfType<DeathHandler>();
            player.HandleDeath();
        }
        taskText.text = Mathf.Round(gettingOutTimer).ToString();
    }
    private void Level6Countdown() {
        lastTimer = lastTimer - Time.deltaTime;
        transitionCanvas.GetComponent<Animator>().SetBool("isEnd", true);
        if(lastTimer < 0.5f) {
            cursorHandler.SetCursorInMenuState(false);
            SceneManager.LoadScene(0);
        }
    }
}
