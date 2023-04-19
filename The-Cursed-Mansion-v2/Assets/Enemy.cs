using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    public GameObject bloodEffect;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        Instantiate(bloodEffect, transform.position, Quaternion.identity) ;
        currentHealth -= damage;

        // Play hurt animation

        if(currentHealth <= 0)
        {
            Die();     
        }
    }

    void Die()
    {
       EnemyPatrol.instance.animator.SetTrigger("DeathGhost");
    }

}
