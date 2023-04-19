using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPicsTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
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
    }
}
