using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed; // Sa vitesse
    public Transform[] waypoints; // Liste des points de l'ennemi

    public int damageOnCollision;

    private Transform target; // Point courant ciblé
    private int destPoint = 0; // Indice du point courant ciblé
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
            target = waypoints[destPoint]; // Choix du nouveau point ciblé
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
