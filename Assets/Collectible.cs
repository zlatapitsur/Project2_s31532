using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //TODO check if collision is Player
       if (!collision.gameObject.CompareTag("Player"))
        {

            return;

        }
        //TODO send info to player
        Inventory playerInventory = null;
        playerInventory = collision.gameObject.GetComponent<Inventory>();

        //player inventory
        //TODO Delete collectible
        Destroy(gameObject);

    }
}
