using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] float hitPoints = 100f;

    // Update is called once per frame
    void Update()
    {
        if (hitPoints <= 0) {
            EnemyDeath();
        }
    }

    public void DecreaseHealth(float damage) {
        hitPoints = hitPoints - damage;
    }

    void EnemyDeath() {
        Destroy(gameObject);
        Debug.Log("Enemy has been killed.");
    }
}
