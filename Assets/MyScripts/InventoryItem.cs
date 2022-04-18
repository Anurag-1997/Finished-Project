using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName="New Item",menuName="Inventory/Item")]
public class InventoryItem : ScriptableObject
{
    new public string Name = "New Item";
    new public Sprite icon = null;
    public bool isDefaultItem = false;




}
