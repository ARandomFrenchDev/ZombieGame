using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float playerHealth = 100f;
    [SerializeField] Image playerHealthImage;

    void Update() {
        playerHealthImage.fillAmount = playerHealth / 100f;
    }
    
    public void DecreaseHealth(float damage) {
        playerHealth -= damage;
        if (playerHealth <= 0) {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }

    public void IncreaseHealth(float health) {
        if (playerHealth + health > 100) {
            playerHealth = 100;
        } else {
            playerHealth += health;
        }
    }
}
