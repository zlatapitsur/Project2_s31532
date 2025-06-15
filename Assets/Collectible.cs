using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int itemIndex = 0;

    private bool playerInRange = false;
    private SimpleInventory inventory;
    private InventoryUI inventoryUI;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (inventory != null)
            {
                Transform slot = inventory.GetSlot(itemIndex);
                if (slot != null && slot.childCount == 0)
                {
                    transform.position = slot.position;
                    transform.SetParent(slot);
                    inventory.UpdateUI();
                }

                if (inventoryUI != null)
                {
                    inventoryUI.AddItem(itemIndex);
                    Destroy(gameObject); // видаляємо предмет зі сцени
                }

                Destroy(this); // відключаємо повторне додавання
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inventory = FindObjectOfType<SimpleInventory>();
            inventoryUI = FindObjectOfType<InventoryUI>();
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            inventory = null;
            inventoryUI = null;
        }
    }
}