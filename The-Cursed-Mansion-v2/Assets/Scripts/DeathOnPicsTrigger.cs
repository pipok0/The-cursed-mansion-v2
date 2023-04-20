using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathOnPicsTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth.instance.takeDamage(100);
        }
    }
}
