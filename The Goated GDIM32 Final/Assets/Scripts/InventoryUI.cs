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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) SelectSlot(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SelectSlot(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) SelectSlot(2);
        if (Input.GetKeyDown(KeyCode.Alpha4)) SelectSlot(3);
        if (Input.GetKeyDown(KeyCode.Alpha5)) SelectSlot(4);
        if (Input.GetKeyDown(KeyCode.Alpha6)) SelectSlot(5);
        if (Input.GetKeyDown(KeyCode.Alpha7)) SelectSlot(6);

        
        if (Input.GetKeyDown(KeyCode.Q))
        {
                DropItem();
        }
        
    }

    void SelectSlot(int index)
    {
        selectedIndex = index;

        Debug.Log("Selected slot " + index);
    }

    void DropItem()
    {
        if (selectedIndex >= inventory.items.Count) return;

        ItemData item = inventory.items[selectedIndex];

        GameObject obj = Instantiate(item.prefab);

        obj.transform.position = player.transform.position + player.transform.forward * 0.5f;

        RaycastHit hit;
        if (Physics.Raycast(obj.transform.position + Vector3.up * 1f, Vector3.down, out hit, 5f))
        {
            obj.transform.position = hit.point;
        }

        inventory.Remove(item);

        Refresh();
    }

    public void Refresh()
    {
        Debug.Log("Refresh called");
        Debug.Log(slotContainer.childCount);

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
    }

    

    
}