using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthScript : MonoBehaviour
{
    [SerializeField] private Image frontHealthBar;

    private float health;
    private float maxHealth = 100f;

    private void Start() {
        health = maxHealth;
    }

    private void Update() {
  
    }

    private void UpdateHealthUI() {
        // fillFront = frontHealthBar.fillAmount;
        // fillBack = frontHealthBar.fillAmount;

        frontHealthBar.fillAmount = 0.5f;
    }

    private void TakeDamage(float damage) {
        health -= damage;
        health = Mathf.Clamp(health, 0f, maxHealth);

        frontHealthBar.fillAmount = health / maxHealth;
    }

    private void RestoreHealth(float heal) {
        health += heal;
        health = Mathf.Clamp(health, 0f, maxHealth);

        frontHealthBar.fillAmount = health / maxHealth;
    }
}
