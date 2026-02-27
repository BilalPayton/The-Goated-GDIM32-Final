using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beans : Item
{
    protected override void OnMouseDown()
    {
        base.OnMouseDown();
        Debug.Log("You have been healed for 10 health");
    }
}
