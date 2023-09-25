using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskHandler : MonoBehaviour
{
    [SerializeField] TMP_Text taskText;
    [SerializeField] float gettingOutTimer = 60f;
    public float taskScorePointsTotal = 0f;
    public int activeWeaponScene;

    public bool canSwitchWeapon = true;

    void Update() {
        HandleTask();
    }

    void HandleTask() {
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        if(currentScene == 1) {
            taskText.text = "DÉTRUIS LES CIBLES :)";
            activeWeaponScene = 0;
            canSwitchWeapon = false;
        } else if(currentScene == 2) {
            taskText.text = "ENQUETE.";
            activeWeaponScene = 2;
            canSwitchWeapon = false;
        } else if(currentScene == 3) {
            activeWeaponScene = 2;
            canSwitchWeapon = true;
            taskText.color = Color.red;
            Level3Countdown();
        } else if(currentScene == 4) {
            activeWeaponScene = 0;
            canSwitchWeapon = true;
            taskText.text = "Va voir la cabane.";
        } else if(currentScene == 5) {
            activeWeaponScene = 1;
            canSwitchWeapon = false;
            taskText.text = "VISITE.";
        } else if(currentScene == 6) {
            activeWeaponScene = 1;
            canSwitchWeapon = true;
            taskText.text = "LA CABANE LA CABANE LA CABANE LA CABANE LA CABANE";
        } else if(currentScene == 7) {
            activeWeaponScene = 0;
            taskText.text = "?";
            canSwitchWeapon = false;
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

}
