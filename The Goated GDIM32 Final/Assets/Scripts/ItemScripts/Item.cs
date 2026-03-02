using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    [SerializeField] private ItemData _data;

    protected void OnMouseOver()
    {
        Debug.Log("You are hovering over the Item");
    }

    protected void OnMouseExit()
    {
        Debug.Log("You are no longer hovering over the Item");
    }

    protected virtual void OnMouseDown()
    {
        Player.Instance.player._inventory.Add(_data);

        InventoryUI ui = FindObjectOfType<InventoryUI>();
        if (ui != null && ui.inventory != null)
        {
                ui.inventory.Add(_data);
                ui.Refresh();
        }

        Destroy(gameObject);
    }
}
