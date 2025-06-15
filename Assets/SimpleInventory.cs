using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SimpleInventory : MonoBehaviour
{
    [Header("Optional item prefabs (for testing with keys)")]
    public GameObject[] itemPrefabs;

    [Header("Inventory Slot Positions")]
    public Transform[] slotPositions;

    [Header("UI")]
    public TextMeshProUGUI itemCounterText;

    public Transform GetSlot(int index)
    {
        if (index >= 0 && index < slotPositions.Length)
            return slotPositions[index];

        Debug.LogWarning("⚠️ Invalid slot index: " + index);
        return null;
    }

    public void UpdateUI()
    {
        if (itemCounterText != null)
        {
            int itemCount = 0;
            foreach (var slot in slotPositions)
            {
                if (slot.childCount > 0)
                    itemCount++;
            }

            itemCounterText.text = "Items: " + itemCount;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            AddItemByPrefab(0);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            AddItemByPrefab(1);
    }

    public void AddItemByPrefab(int itemIndex)
    {
        if (itemIndex < 0 || itemIndex >= itemPrefabs.Length || itemIndex >= slotPositions.Length)
        {
            Debug.LogWarning("❌ Invalid index or slot missing.");
            return;
        }

        if (slotPositions[itemIndex].childCount > 0)
        {
            Debug.Log("⚠️ Slot " + itemIndex + " is already occupied.");
            return;
        }

        GameObject newItem = Instantiate(itemPrefabs[itemIndex], slotPositions[itemIndex].position, Quaternion.identity);
        newItem.transform.SetParent(slotPositions[itemIndex]);

        Debug.Log("✅ Spawned item in slot " + itemIndex);

        UpdateUI();
    }
}