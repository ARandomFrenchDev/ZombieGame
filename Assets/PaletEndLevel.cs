using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PaletEndLevel : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") {
            SceneManager.LoadScene(3);
        }
    }
}
