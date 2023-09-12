using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHandle : MonoBehaviour
{
    [SerializeField] float points;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip shotSFX;
    
    public void HandlePoints() {
        StartCoroutine(CoroutineExecution());
    }

    IEnumerator CoroutineExecution() {
        audioSource.PlayOneShot(shotSFX);
        yield return new WaitUntil(() => !audioSource.isPlaying);
        Destroy(gameObject.transform.parent.gameObject);

    }

}
