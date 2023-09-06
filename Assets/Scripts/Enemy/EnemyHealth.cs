using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] float hitPoints = 100f;

    bool isDead = false;

    // Update is called once per frame

    public bool IsDead() {
        return isDead;
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
        GetComponent<AudioSource>().enabled = false;
        isDead = true;
        Debug.Log("Enemy has been killed.");
    }
}
