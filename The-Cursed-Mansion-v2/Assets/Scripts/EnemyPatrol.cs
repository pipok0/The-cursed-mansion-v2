using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed; // Sa vitesse
    public Transform[] waypoints; // Liste des points de l'ennemi

    public int damageOnCollision;

    public SpriteRenderer graphics;
    private Transform target; // Point courant cibl�
    private int destPoint = 0; // Indice du point courant cibl�
    public static EnemyPatrol instance;
    public Animator animator;

     private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de EnemyPatrol dans la scène");
            return;
        }

        instance = this;
    }


    void Start()
    {
        target = waypoints[0];
    }

    
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length; // Boucle
            target = waypoints[destPoint]; // Choix du nouveau point cibl�
            graphics.flipX = !graphics.flipX;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player")) {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.takeDamage(damageOnCollision);
        }
    }
}
