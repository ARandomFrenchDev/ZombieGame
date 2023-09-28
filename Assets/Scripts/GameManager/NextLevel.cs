using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    [SerializeField] int levelToGo;
    [SerializeField] Canvas transitionCanvas;
    void Start() {
        Time.timeScale = 1.0f;
        transitionCanvas.enabled = false;
        transitionCanvas.GetComponent<Animator>().SetBool("isChangingLevel", false);
        transitionCanvas.GetComponent<Animator>().SetBool("isEnd", false);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") {
            other.gameObject.GetComponent<PlayerHealth>().IncreaseHealth(1000);
            HandleNextScene(levelToGo);
        }
    }

    public void HandleNextScene(int levelToGo) {
        StartCoroutine(LoadNextScene(levelToGo));       
    }

    IEnumerator LoadNextScene(int levelToGo) {
        transitionCanvas.enabled = true;
        transitionCanvas.GetComponent<Animator>().SetBool("isChangingLevel", true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(levelToGo);
    }

    // get Transition Canvas
    // make transition open
}
