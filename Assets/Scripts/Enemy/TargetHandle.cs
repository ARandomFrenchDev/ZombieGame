using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TargetHandle : MonoBehaviour
{
    [SerializeField] float points;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip shotSFX;
    [SerializeField] ParticleSystem fireworksEffect;
    [SerializeField] GameObject components;
    [SerializeField] TMP_Text scoreText;
    TaskHandler taskHandler;

    void Start() {
        taskHandler = FindObjectOfType<TaskHandler>();
        scoreText.text = "SCORE : " + taskHandler.taskScorePointsTotal;
    }
    
    public void HandlePoints() {
        StartCoroutine(CoroutineExecution());
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

}
