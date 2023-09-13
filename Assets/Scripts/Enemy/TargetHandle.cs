using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetHandle : MonoBehaviour
{
    [SerializeField] float points;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip shotSFX;
    [SerializeField] ParticleSystem fireworksEffect;
    [SerializeField] GameObject components;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] bool isCursed = false;
    float shootCount = 3;
    TaskHandler taskHandler;

    void Start() {
        taskHandler = FindObjectOfType<TaskHandler>();
        scoreText.text = "SCORE : " + taskHandler.taskScorePointsTotal;
    }
    
    public void HandlePoints() {
        if(!isCursed) {
            StartCoroutine(CoroutineExecution());
        } else {
            HandleShotCursed();
        }
    }

    IEnumerator CoroutineExecution() {
        audioSource.PlayOneShot(shotSFX);
        Instantiate(fireworksEffect, transform.position, transform.rotation);
        components.SetActive(false);
        TaskShootTargets();
        yield return new WaitUntil(() => !audioSource.isPlaying);
        Destroy(gameObject.transform.parent.gameObject);

    }

    void TaskShootTargets() {
        taskHandler.taskScorePointsTotal = taskHandler.taskScorePointsTotal + points;
        scoreText.text = "SCORE : " + taskHandler.taskScorePointsTotal.ToString();
    }

    void HandleShotCursed() {
        shootCount = shootCount - 1;
        audioSource.pitch = Random.Range(0f, 0.5f);
        audioSource.PlayOneShot(shotSFX);
        Instantiate(fireworksEffect, transform.position, transform.rotation);
        if(shootCount <= 0) {
            SceneManager.LoadScene(2);
        }
    }

}
