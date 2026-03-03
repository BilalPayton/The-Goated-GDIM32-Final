using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 1)]
public class ItemData : ScriptableObject
{
    public string _name;
    public string _description;
    public Sprite _icon;
    public GameObject prefab;
    
}
