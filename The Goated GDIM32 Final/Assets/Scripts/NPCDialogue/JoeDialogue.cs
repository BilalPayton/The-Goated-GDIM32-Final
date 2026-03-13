using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoeDialogue : NPCMultipleBranches
{
    protected override void CheckForQuestItem()
    {
        foreach (ItemData item in Player.Instance.player._inventory)
        {
            if (item._name.Equals("Beans"))
            {
                _currentNode = _questCompleteNode;
            }
        }

    }
}
