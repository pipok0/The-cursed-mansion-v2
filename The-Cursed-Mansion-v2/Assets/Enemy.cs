using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    public Animator animator;
    public bool isDead = false;
    public static Enemy instance;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Play hurt animation

        if(currentHealth <= 0)
        {
            Die();     
        }
    }

    void Die()
    {    
     isDead = true;   
     GetComponent<EnemyPatrol>().enabled = false;
     Inventory.instance.AddCoins(2);
     animator.SetTrigger("Die");
     GetComponent<BoxCollider2D>().enabled = false; // désactiver le BoxCollider2D
    }

}
