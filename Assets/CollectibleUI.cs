using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleUI : MonoBehaviour
{
    public int itemIndex = 0;

    private bool playerInRange = false;
    private InventoryUI inventoryUI;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (inventoryUI != null)
            {
                inventoryUI.AddItem(itemIndex);
                Destroy(gameObject); // видаляємо предмет зі сцени
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inventoryUI = FindObjectOfType<InventoryUI>();
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            inventoryUI = null;
        }
    }
}