using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] int levelToGo;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") {
            SceneManager.LoadScene(levelToGo);
        }
    }
}
