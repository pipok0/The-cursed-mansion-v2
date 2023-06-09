using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{


    public Animator animator;
    public Transform attackPoint;
    public Transform attackPointRight;
    public Transform attackPointLeft;
    public LayerMask enemyLayers;
    public float attackRange = 0.5f;
    public int attackDamage = 40;
    public float attackRate = 1f;
    float nextAttackTime = 0f;
    public bool isAttacking = false;

    // Update is called once per frame
    void Update()
    {

        if (Time.time >= nextAttackTime)
        {  
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                StartCoroutine(Attack());
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    IEnumerator Attack()
    {

        // Animation d'attaque
        animator.SetTrigger("Attack");

        // Détecte les ennemis à notre portée
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);


        yield return new WaitForSeconds(0.3f);

        // Leur infliger des dégâts
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            attackPointRight.gameObject.SetActive(true);
            attackPointLeft.gameObject.SetActive(false);
            attackPoint = attackPointRight;

        }
        else if (_velocity < -0.1f)
        {
            attackPointRight.gameObject.SetActive(false);
            attackPointLeft.gameObject.SetActive(true);
            attackPoint = attackPointLeft;
        }
    }

}
