using UnityEngine;


[CreateAssetMenu(fileName = "ItemObject", menuName = "Scriptable Objects/ItemObject")]
public class ItemObject : ScriptableObject
{
    public int Id;
    public Sprite uiDisplay;
    public GameObject ObjectModel;

    public string Name;
    [TextArea(15, 20)]
    public string Description;

    public bool IsCurrency;

    public Item createItem()
    {
        Item newItem = new Item(this);
        return newItem;
    }
}

[System.Serializable]
public class Item
{
    public string Name;
    public string Description;
    public int Id;
    public GameObject AssetModel;
    public bool IsCurrency;

    public Item()
    {
        Name = "";
        Id = 0;
    }

    public Item(ItemObject item)
    {
        Name = item.name;
        Description = item.Description;
        Id = item.Id;
        AssetModel = item.ObjectModel;
        IsCurrency = item.IsCurrency;
    }
}