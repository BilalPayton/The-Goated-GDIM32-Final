using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoeDialogue : NPCMultipleBranches
{
    [SerializeField] private ItemData carKey;
    //private bool _beansGiven = false;

    /*public void GiveBeans()
    {
        _beansGiven = true;

        GameObject beans = GameObject.FindWithTag("QuestItem");

        if (beans != null)
        {
            Destroy(beans);
        }
    }*/

    protected override void CheckForQuestItem()
    {
        /*foreach (ItemData item in Player.Instance.player._inventory)
        {
            if (item._name.Equals("Beans"))
            {
                _currentNode = _questCompleteNode;
            }
        }*/
        //Change the giving beans logic to drop the beans then have the next quest

        GameObject[] beans = GameObject.FindGameObjectsWithTag("QuestItem");

        foreach (GameObject bean in beans)
        {
            float distance = Vector3.Distance(transform.position, bean.transform.position);

            if (distance < 4f)
            {
                Destroy(bean);
                _currentNode = _questCompleteNode;

                GameController.instance.AdvanceState();

                InventoryUI ui = FindObjectOfType<InventoryUI>();

                if (ui != null && ui.inventory != null)
                {
                    ui.inventory.Add(carKey);
                    ui.Refresh();

                    if (ui.itemUI != null)
                    {
                        ui.itemUI.ShowCollected(carKey._name);
                    }
                }
                    
                return;

            }
            
            
        }

    }
}
