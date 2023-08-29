using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float playerHealth = 100f;

    public void DecreaseHealth(float damage) {
        playerHealth -= damage;
        Debug.Log("L'ennemi fait des dégats.");
        if (playerHealth <= 0) {
            Debug.Log("Tu es mort.");
        }
    }

    public void IncreaseHealth(float health) {
        if (playerHealth + health > 100) {
            playerHealth = 100;
        } else {
            playerHealth += health;
            Debug.Log("Santé récupérée.");
        }
    }
}
