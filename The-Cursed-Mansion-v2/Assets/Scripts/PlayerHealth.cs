using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public float invincibilityTime = 3f;
    public float invicibilityFlashDelay = 0.15f;
    public bool isInvicible = false;

    public SpriteRenderer graphics;
    public HealthBar healthBar;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H)){
            takeDamage(20);
        }
    }

    public void takeDamage(int damage) {
        if (!isInvicible)
        {
            currentHealth -= damage;
            healthBar.setHealth(currentHealth);
            isInvicible = true;
            StartCoroutine(invincibilityFlash());
            StartCoroutine(handleInvincibilityDelay());
        }
    }

    public IEnumerator invincibilityFlash() {
        while (isInvicible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f); // Transparent
            yield return new WaitForSeconds(invicibilityFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f); // Visible
            yield return new WaitForSeconds(invicibilityFlashDelay);
        }
    }

    public IEnumerator handleInvincibilityDelay()
    {
        yield return new WaitForSeconds(invincibilityTime);
        isInvicible = false;
    }
}
