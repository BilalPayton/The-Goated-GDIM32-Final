using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InventorySlot : MonoBehaviour
{
    public int index;
    public Inventory inventory;

    public void OnClick()
    {
        if (index >= inventory.items.Count) return;

        ItemData item = inventory.items[index];

        GameController.instance.GiveItem(item);
    }
}