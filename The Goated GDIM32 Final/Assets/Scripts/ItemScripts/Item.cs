using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    [SerializeField] private ItemData _data;

    private bool pickupAllowed = true;

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
        //Player.Instance.player._inventory.Add(_data);

        if (!pickupAllowed)
        {
            return;
        }
        InventoryUI ui = FindObjectOfType<InventoryUI>();

        if (ui != null && ui.inventory != null)
        {
            ui.inventory.Add(_data);
            ui.Refresh();

            if (ui.itemUI != null)
            {
                ui.itemUI.ShowCollected(_data._name);
            }
        }

        if (_data._name == "Beans")
        {
            GameController.instance.AdvanceState();
        }

        Destroy(gameObject);
    }
    
    


    public virtual void Use(ItemUI ui)
    {
        if (ui != null)
        {
            ui.ShowMessage("You used " + _data._name);
        }
    }

    public virtual void SetPickup (bool value)
    {
        pickupAllowed = value;
    }
}


