using UnityEngine;


public enum ItemType
{
    Misc,
    One_Handed_Wepon,//Wepons
    Two_Handed_Wepon,
    Short_Bow_Wepon,
    Long_Bow_Wepon,
    CrossBows_Wepon,
    Spell_Focus,
    Artifacts,
    Head_Armour, //Armour Tabs
    Body_Armour,
    Legs_Armour,
    Shoe_Armour,
    Equipment,
    Accessories,
    Quest_Items, //Items Tabs
    Tools,
    Matirals,
    Ingredients,
    Ammo,
    Potions,
    Food,
}
public enum AreaOfTheBody
{
    StorageOnly,
    Hair,
    Head,
    Glaseses,

    LeftEar,
    RightEar,
    Nose,
    Mouth,
    Neck,

    Body,
    back,

    Arms,//leftHand
    //Righthand

    Wrists,
    hands,
    Thumbfinger,
    Indexfinger,
    Middlefinger,
    Ringfinger,
    Pinkyfinger,

    ClothingTop,
    ClothingMiddle,
    ClothingBottom,

    Legs,
    Ankles,
    Feet,
}

public enum Rareity
{
    Mythic,         // Only 1 Ever Made         Or Power rating ____
    Legandary,      // Bellow 5 Ever Made       Or Power rating ____
    Epic,           // Bellow 50 Ever Made      Or Power rating ____
    Rare,           // bellow 100 Ever Made     Or Power rating ____
    Uncommon,       // Bellow 300 Ever Made     Or Power rating ____
    Common,         // Above 300 ever Made      Or Power rating ____
}
public enum Attributes
{
    Strength,
    dexterity,
    constitution,
    Intellect,
    Wisdom,
    Charisma,
    Stamina,
    Defence,
    CarryingCapacity,
}

[CreateAssetMenu(fileName = "ItemObject", menuName = "Scriptable Objects/ItemObject")]
public class ItemObject : ScriptableObject
{
    public int Id;
    public Sprite uiDisplay;
    public GameObject ObjectModel;
    public ItemType type;
    public AreaOfTheBody Place;

    public string Name;
    [TextArea(15, 20)]
    public string Description;
    public int HandsRequired = 1;

    public bool Stackable;
    public bool IsCurrency;

    public bool Equipable;
    public bool Attuneable;
    public bool Attuned;

    public ItemBuff[] buffs;
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

    public int HandsRequired;

    public bool Stackable;
    public bool Equipable;
    public bool Attuneable;
    public bool Attuned;
    public ItemBuff[] buffs;
    public ItemType type;
    public AreaOfTheBody Place;

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
        HandsRequired = item.HandsRequired;
        Stackable = item.Stackable;
        Equipable = item.Equipable;
        Attuneable = item.Attuneable;
        Attuned = item.Attuned;
        buffs = new ItemBuff[item.buffs.Length];
        type = item.type;
        Place = item.Place;

        for (int i = 0; i < buffs.Length; i++)
        {
            buffs[i] = new ItemBuff(item.buffs[i].Min, item.buffs[i].Max);
            {
                buffs[i].Attribute = item.buffs[i].Attribute;
            }
        }
    }
}

[System.Serializable]
public class ItemBuff
{
    public Attributes Attribute;
    public int Value;
    public int Min;
    public int Max;
    public ItemBuff(int _min, int _max)
    {
        Min = _min;
        Max = _max;
        GenirateValue();
    }
    public void GenirateValue()
    {
        Value = UnityEngine.Random.Range(Min, Max);
    }
}