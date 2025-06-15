using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public Image[] slotImages; // UI Images в Canvas (ікони)
    public Sprite[] itemSprites; // Картинки для яблука, хліба і т.д.
    //public TextMeshProUGUI itemCounterText;

    private int itemCount = 0;

    public void AddItem(int itemIndex)
    {
        if (itemIndex < 0 || itemIndex >= slotImages.Length || itemIndex >= itemSprites.Length)
            return;

        if (slotImages[itemIndex].sprite != null)
            return; // слот зайнятий

        slotImages[itemIndex].sprite = itemSprites[itemIndex];
        slotImages[itemIndex].color = Color.white;
        itemCount++;

        //if (itemCounterText != null)
        //    itemCounterText.text = "Items: " + itemCount;
    }
}