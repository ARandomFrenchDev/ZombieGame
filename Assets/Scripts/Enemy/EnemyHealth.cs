using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] float hitPoints = 100f;
    [SerializeField] AudioClip deathSound;

    bool isDead = false;
    AudioSource audioSource;


    // Update is called once per frame

    public bool IsDead() {
        return isDead;
    }

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (hitPoints <= 0) {
            EnemyDeath();
        }
    }

    public void DecreaseHealth(float damage) {
        if(hitPoints > 0) {
            hitPoints = hitPoints - damage;
            GetComponent<EnemyAI>().OnDamageTaken();
        }
    }

    void EnemyDeath() {
        if(isDead) return;
        GetComponent<Animator>().SetTrigger("isDead");
        // audioSource.Stop();
        audioSource.loop = false;
        audioSource.PlayOneShot(deathSound);

        isDead = true;
        Debug.Log("Enemy has been killed.");
    }
}
