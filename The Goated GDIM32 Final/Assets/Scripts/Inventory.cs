using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Inventory/InventoryUI")]
public class Inventory : ScriptableObject
{
    public List<ItemData> items = new List<ItemData>();

    public void Add(ItemData item)
    {
        items.Add(item);
        Debug.Log(this.items.Count);
    }

    public void Remove(ItemData item)
    {
        items.Remove(item);
    }

}