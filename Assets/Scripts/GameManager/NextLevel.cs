using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    [SerializeField] int levelToGo;
    [SerializeField] Canvas transitionCanvas;
    [SerializeField] Image tvScreen;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") {
            StartCoroutine(LoadNextScene(levelToGo));
            SceneManager.LoadScene(levelToGo);
        }
    }

    IEnumerator LoadNextScene(int levelToGo) {
        transitionCanvas.GetComponent<CanvasGroup>().alpha = 1f;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(levelToGo);
    }

    // get Transition Canvas
    // make transition open
}
