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

    public bool canSwitchWeapon = true;

    void Update() {
        HandleTask();
    }

    void HandleTask() {
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        if(currentScene == 1) {
            taskText.text = "DÉTRUIS LES CIBLES :)";
            canSwitchWeapon = false;
        } else if(currentScene == 2) {
            taskText.text = "SURVIS.";
            canSwitchWeapon = false;
        } else if(currentScene == 3) {
            canSwitchWeapon = true;
            gettingOutTimer = gettingOutTimer - Time.deltaTime;
            taskText.text = gettingOutTimer.ToString();
            taskText.color = Color.red;
        } else if(currentScene == 4) {
            canSwitchWeapon = true;
            taskText.text = "Va voir la cabane.";
        } else if(currentScene == 5) {
            canSwitchWeapon = false;
            taskText.text = "VISITE.";
        } else if(currentScene == 6) {
            canSwitchWeapon = true;
            taskText.text = "LA CABANE LA CABANE LA CABANE LA CABANE LA CABANE";
        } else if(currentScene == 7) {
            taskText.text = "?";
            canSwitchWeapon = false;
        }
    }

}
