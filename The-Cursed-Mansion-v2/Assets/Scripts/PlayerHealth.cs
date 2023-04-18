using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public float invincibilityTime = 3f;
    public float invincibilityFlashDelay = 0.2f;
    public bool isInvincible = false;

    public SpriteRenderer graphics;
    public HealthBar healthBar;

    public static PlayerHealth instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerHealth dans la scène");
            return;
        }

        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            takeDamage(60); //pour les tests
        }
    }

    public void takeDamage(int damage)
    {
        if (!isInvincible)
        {
            //on lui retire les vies
            currentHealth -= damage;

            //mis à jour de la barre de vie
            healthBar.setHealth(currentHealth);

            //Verifier si le joueur est toujours vivant
            if(currentHealth <= 0)
            {
                Die();
                return;
            }

            isInvincible = true;
            StartCoroutine(invincibilityFlash());
            StartCoroutine(handleInvincibilityDelay());
        }
    }

    public void Die()
    {
        Debug.Log("Le joueur est éliminé");//test

        //Bloquer les mouvements du personnage
        PlayerMovement.instance.enabled = false;
        //Jouer l'animation de Mort
        PlayerMovement.instance.animator.SetTrigger("Die");
        //Empecher les interactions physique avec les autres éléments de la scène
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        PlayerMovement.instance.rb.velocity = Vector3.zero;
        PlayerMovement.instance.playerCollider.enabled = false;

    }

    public IEnumerator invincibilityFlash()
    {
        while (isInvincible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f); // Transparent
            yield return new WaitForSeconds(invincibilityFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f); // Visible
            yield return new WaitForSeconds(invincibilityFlashDelay);
        }
    }

    public IEnumerator handleInvincibilityDelay()
    {
        yield return new WaitForSeconds(invincibilityTime);
        isInvincible = false;
    }
}
