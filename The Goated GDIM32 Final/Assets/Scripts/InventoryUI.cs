using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public Transform slotContainer;
    public Transform player;
    public int selectedIndex = 0;
    public ItemUI itemUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) SelectSlot(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SelectSlot(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) SelectSlot(2);
        if (Input.GetKeyDown(KeyCode.Alpha4)) SelectSlot(3);
        if (Input.GetKeyDown(KeyCode.Alpha5)) SelectSlot(4);
        if (Input.GetKeyDown(KeyCode.Alpha6)) SelectSlot(5);
        if (Input.GetKeyDown(KeyCode.Alpha7)) SelectSlot(6);


        if (Input.GetKeyDown(KeyCode.E))
        {
            UseItem();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            DropItem();
        }

    }
    private void Awake()
    {
        inventory.ResetInventory();
    }
    private void Start()
    {
        Refresh();
    }
    private void SelectSlot(int index)
    {
        selectedIndex = index;

        Debug.Log("Selected slot " + index);

        if (index < inventory.items.Count)
        {
            itemUI.ShowItem(inventory.items[index]._name);
        }
    }

    private void UseItem()
    {
        ItemData item = inventory.items[selectedIndex];

        Item allItem = item.prefab.GetComponent<Item>();

        if (allItem != null)
        {
            allItem.Use(itemUI);
        }

        inventory.Remove(item);
        Refresh();
 
    }

    private void DropItem()
    {
        if (selectedIndex >= inventory.items.Count) return;

        ItemData item = inventory.items[selectedIndex];

        GameObject obj = Instantiate(item.worldPrefab);

        obj.transform.localScale = Vector3.one;


        Vector3 forward = player.transform.forward;
        forward.y = 0;

        Vector3 dropPosition = player.transform.position + forward * 1.5f;

        RaycastHit hit;

        if (Physics.Raycast(dropPosition + Vector3.up * 2f, Vector3.down, out hit, 5f))
        {
            obj.transform.position = hit.point;
        }
        else
        {
            obj.transform.position = dropPosition;
        }

        inventory.Remove(item);

        Refresh();

        Item itemScript = obj.GetComponent<Item>();
        if (itemScript != null)
        {
            itemScript.SetPickup(false);
        }

        if (itemUI != null)
        {
            itemUI.ShowMessage(item._name + " dropped.");
        }

        
    }

    public void Refresh()
    {
        Debug.Log("Refresh called");

        for (int i = 0; i < slotContainer.childCount; i++)
        {
            Image image = slotContainer.GetChild(i).GetComponent<Image>();


            if (i < inventory.items.Count)
            {
                image.sprite = inventory.items[i]._icon;
                //image.color = Color.red;
                //image.enabled = true;
            }
            else
            {
                image.sprite = null;
            }
            
        }

        if (inventory.items.Count > 0 && itemUI != null)
            {
                ItemData lastItem = inventory.items[inventory.items.Count - 1];
                itemUI.ShowCollected(lastItem._name);
            }
    }

    

    
}