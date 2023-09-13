using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] float hitPoints = 100f;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AmmoPickup ammoPickup;

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
        isDead = true;
        GetComponent<Animator>().SetTrigger("isDead");
        audioSource.pitch = Random.Range(0.8f, 1f);
        audioSource.PlayOneShot(deathSound);
        Vector3 pickupPos = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        Instantiate(ammoPickup, pickupPos, transform.rotation);
    }
}
