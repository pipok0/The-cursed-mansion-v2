using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    public GameObject objectToDestroy;
    public Inventory inventory;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player")) {
            Destroy(objectToDestroy);
            inventory.AddCoins(1);
        }
    }
}
