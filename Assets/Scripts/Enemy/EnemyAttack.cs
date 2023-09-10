using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float attackDamage = 10f;
    [SerializeField] AudioClip attackSound;

    AudioSource audioSource;

    void Start() {
        audioSource = GetComponent<AudioSource>();
        target = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent() {
        if(target == null) return;
        // audioSource.pitch = Random.Range(audioSource.pitch, audioSource.pitch - 0.3f);
        audioSource.PlayOneShot(attackSound);
        target.DecreaseHealth(attackDamage);
    }
}
