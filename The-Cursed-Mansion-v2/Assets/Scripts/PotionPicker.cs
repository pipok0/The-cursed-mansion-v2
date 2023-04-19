using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionPicker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerMovement>().moveSpeed = 600f;
            Destroy(gameObject);
        }
    }
}