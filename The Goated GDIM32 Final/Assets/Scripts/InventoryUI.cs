using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public Transform slotContainer;

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