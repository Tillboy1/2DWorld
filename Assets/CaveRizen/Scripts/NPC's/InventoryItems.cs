using NUnit.Framework;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItems", menuName = "Scriptable Objects/InventoryItems")]
public class InventoryItems : ScriptableObject
{
    [TextArea(5, 10)]
    public string description;
    public bool ableToStack;
    public int amount;
    public Sprite icon;
    public int cost;
}