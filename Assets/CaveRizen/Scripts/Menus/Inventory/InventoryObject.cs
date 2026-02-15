using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;
using System.Runtime.Serialization;
using static UnityEditor.Progress;

[CreateAssetMenu(fileName = "InventoryObject", menuName = "Scriptable Objects/InventoryObject")]
public class InventoryObject : ScriptableObject
{
    public string SavePath;
    public ItemDatabaseObject database;
    public Inventory container;
    public EquipmentInv EquipableContainer;


    // equipment spaces in EquipmentInv for the array size

    public float CurrentWeight, MaxWeight;

    public void AddItem(Item _item, int _Amount)
    {
        if (!_item.Stackable)
        {
            container.Items.Add(new InventorySlot(_item.Id, _item, _Amount));
            return;
        }

        for (int i = 0; i < container.Items.Count; i++)
        {
            if (container.Items[i].item.Id == _item.Id)
            {
                container.Items[i].AddAmount(_Amount);
                return;
            }
        }
        container.Items.Add(new InventorySlot(_item.Id, _item, _Amount));
    }

    public void EquipItem(InventorySlot Slot, string hands)
    {

        Item _item = null;
        int _Amount = 1;

        int LocationSaved = 0;

        for (int i = 0; i < container.Items.Count; i++)
        {
            if (container.Items[i].ID == Slot.ID)
            {
                _item = container.Items[i].item;
                _Amount = container.Items[i].amount;
            }
        }

        #region where to add too
        if (hands == "Item")
        {
            switch (Slot.item.Place)
            {
                case AreaOfTheBody.Hair:
                    LocationSaved = 0; // helmets hair ties
                    break;
                case AreaOfTheBody.Head:
                    LocationSaved = 1; // jewlry and headties
                    break;
                case AreaOfTheBody.Glaseses:
                    LocationSaved = 2; // glases and magnifing glass
                    break;
                case AreaOfTheBody.LeftEar:
                    for (int i = 0; i < 3; i++)
                    {
                        if (EquipableContainer.Items[3 + i].item.Name == "")
                        {
                            LocationSaved = 3 + i;
                            Debug.Log(LocationSaved + "Working!");
                            break;
                        }
                        //LocationSaved = 3; //
                        //LocationSaved = 4; //
                        //LocationSaved = 5; //
                    }
                    break;
                case AreaOfTheBody.RightEar:
                    for (int i = 0; i < 3; i++)
                    {
                        if (EquipableContainer.Items[6 + i].item.Name == "")
                        {
                            LocationSaved = 6 + i;
                            Debug.Log(LocationSaved + "Working!");
                            break;
                        }
                        //LocationSaved = 6; //
                        //LocationSaved = 7; //
                        //LocationSaved = 8; //
                    }
                    break;
                case AreaOfTheBody.Nose:
                    for (int i = 0; i < 3; i++)
                    {
                        if (EquipableContainer.Items[9 + i].item.Name == "")
                        {
                            LocationSaved = 9 + i;
                            Debug.Log(LocationSaved + "Working!");
                            break;
                        }
                        //LocationSaved = 9;  // Left
                        //LocationSaved = 10; // middle
                        //LocationSaved = 11; // Right
                    }
                    break;
                case AreaOfTheBody.Mouth:
                    for (int i = 0; i < 6; i++)
                    {
                        if (EquipableContainer.Items[12 + i].item.Name == "")
                        {
                            LocationSaved = 12 + i;
                            Debug.Log(LocationSaved + "Working!");
                            break;
                        }
                        //LocationSaved = 12; // top left
                        //LocationSaved = 13; // top middle
                        //LocationSaved = 14; // top right
                        //LocationSaved = 15; // bottom left
                        //LocationSaved = 16; // bottom middle
                        //LocationSaved = 17; // bottom right
                    }
                    break;
                case AreaOfTheBody.Neck:
                    for (int i = 0; i < 3; i++)
                    {
                        if (EquipableContainer.Items[18 + i].item.Name == "")
                        {
                            LocationSaved = 18 + i;
                            break;
                        }
                        else
                        {
                            //Debug.Log("the name is: " +EquipableContainer.Items[18 + i].item.Name);
                        }
                        //LocationSaved = 18; //Bottom
                        //LocationSaved = 19; // middle
                        //LocationSaved = 20; // top
                    }
                    break;
                case AreaOfTheBody.Body:
                    for (int i = 0; i < 2; i++)
                    {
                        if (EquipableContainer.Items[21 + i].item.Name == "")
                        {
                            LocationSaved = 21 + i;
                            Debug.Log(LocationSaved + "Working!");
                            break;
                        }
                        //LocationSaved = 21; // main
                        //LocationSaved = 22; // waist
                    }
                    break;
                case AreaOfTheBody.back:
                    LocationSaved = 23; // backpack / kinda
                    break;
                case AreaOfTheBody.Arms:
                    for (int i = 0; i < 4; i++)
                    {
                        if (EquipableContainer.Items[24 + i].item.Name == "")
                        {
                            LocationSaved = 24 + i;
                            Debug.Log(LocationSaved + "Working!");
                            break;
                        }
                        //LocationSaved = 24; // top left
                        //LocationSaved = 25; // elbo left
                        //LocationSaved = 26; // top right
                        //LocationSaved = 27; // elbo right
                    }
                    break;
                case AreaOfTheBody.Wrists:
                    for (int i = 0; i < 4; i++)
                    {
                        if (EquipableContainer.Items[54 + i].item.Name == "")
                        {
                            LocationSaved = 28 + i;
                            Debug.Log(LocationSaved + "Working!");
                            break;
                        }
                        //LocationSaved = 28; // Left one
                        //LocationSaved = 29; // left two
                        //LocationSaved = 30; // right one
                        //LocationSaved = 31; // right two
                    }
                    break;
                case AreaOfTheBody.Thumbfinger:
                    for (int i = 0; i < 4; i++)
                    {
                        if (EquipableContainer.Items[32 + i].item.Name == "")
                        {
                            LocationSaved = 32 + i;
                            Debug.Log(LocationSaved + "Working!");
                            break;
                        }
                        //LocationSaved = 32; // Left one
                        //LocationSaved = 33; // Left two
                        //LocationSaved = 34; // right one
                        //LocationSaved = 35; // right two
                    }
                    break;
                case AreaOfTheBody.Indexfinger:
                    for (int i = 0; i < 6; i++)
                    {
                        if (EquipableContainer.Items[36 + i].item.Name == "")
                        {
                            LocationSaved = 36 + i;
                            Debug.Log(LocationSaved + "Working!");
                            break;
                        }
                        //LocationSaved = 36; // Left one
                        //LocationSaved = 37; // Left two
                        //LocationSaved = 38; // Left three
                        //LocationSaved = 39; // right one
                        //LocationSaved = 40; // right two
                        //LocationSaved = 41; // right three
                    }
                    break;
                case AreaOfTheBody.Middlefinger:
                    for (int i = 0; i < 6; i++)
                    {
                        if (EquipableContainer.Items[42 + i].item.Name == "")
                        {
                            LocationSaved = 42 + i;
                            Debug.Log(LocationSaved + "Working!");
                            break;
                        }
                        //LocationSaved = 42; // Left one
                        //LocationSaved = 43; // Left two
                        //LocationSaved = 44; // Left three
                        //LocationSaved = 45; // right one
                        //LocationSaved = 46; // right two
                        //LocationSaved = 47; // right three
                    }
                    break;
                case AreaOfTheBody.Ringfinger:
                    for (int i = 0; i < 6; i++)
                    {
                        if (EquipableContainer.Items[48 + i].item.Name == "")
                        {
                            LocationSaved = 48 + i;
                            Debug.Log(LocationSaved + "Working!");
                            break;
                        }
                        //LocationSaved = 48; // Left one
                        //LocationSaved = 49; // Left two
                        //LocationSaved = 50; // Left three
                        //LocationSaved = 51; // right one
                        //LocationSaved = 52; // right two
                        //LocationSaved = 53; // right three
                    }
                    break;
                case AreaOfTheBody.Pinkyfinger:
                    for (int i = 0; i < 4; i++)
                    {
                        if (EquipableContainer.Items[54 + i].item.Name == "")
                        {
                            LocationSaved = 54 + i;
                            Debug.Log(LocationSaved + "Working!");
                            break;
                        }
                        //LocationSaved = 54; // Left one
                        //LocationSaved = 55; // Left two
                        //LocationSaved = 57; // right one
                        //LocationSaved = 58; // right two
                    }
                    break;
                case AreaOfTheBody.ClothingTop:
                    for (int i = 0; i < 3; i++)
                    {
                        if (EquipableContainer.Items[59 + i].item.Name == "")
                        {
                            LocationSaved = 59 + i;
                            Debug.Log(LocationSaved + "Working!");
                            break;
                        }
                        //LocationSaved = 59; // pendants medals ect
                        //LocationSaved = 60; // pendants medals ect
                        //LocationSaved = 61; // pendants medals ect
                    }
                    break;
                case AreaOfTheBody.ClothingMiddle:
                    for (int i = 0; i < 3; i++)
                    {
                        if (EquipableContainer.Items[62 + i].item.Name == "")
                        {
                            LocationSaved = 62 + i;
                            Debug.Log(LocationSaved + "Working!");
                            break;
                        }
                        //LocationSaved = 62; // pockets
                        //LocationSaved = 63; // pockets
                        //LocationSaved = 64; // pockets
                    }
                    break;
                case AreaOfTheBody.ClothingBottom:
                    for (int i = 0; i < 3; i++)
                    {
                        if (EquipableContainer.Items[65 + i].item.Name == "")
                        {
                            LocationSaved = 65 + i;
                            Debug.Log(LocationSaved + "Working!");
                            break;
                        }
                        //LocationSaved = 65; // clipable
                        //LocationSaved = 66; // clipable
                        //LocationSaved = 67; // clipable
                    }
                    break;
                case AreaOfTheBody.Legs:
                    LocationSaved = 68; // trousers
                    break;
                case AreaOfTheBody.Feet:
                    LocationSaved = 69; // Shoes nice
                    break;
                default:
                    break;
            }
        }
        else if (hands == "Left")
        {
            LocationSaved = 70;
        }
        else if (hands == "Right")
        {
            LocationSaved = 71;
        }
        else if (hands == "Both")
        {
            LocationSaved = 70;
            LocationSaved = 71;
        }
        #endregion

        #region Adding to equipment
        if (!_item.Stackable)
        {
            EquipableContainer.Items[LocationSaved] = (new InventorySlot(_item.Id, _item, _Amount));
            return;
        }
        // if you can only have one object

        for (int i = 0; i < EquipableContainer.Items.Length; i++)
        {
            if (EquipableContainer.Items[i].item.Id == _item.Id)
            {
                EquipableContainer.Items[i].AddAmount(_Amount);
                return;
            }
        }
        EquipableContainer.Items[LocationSaved] = (new InventorySlot(_item.Id, _item, _Amount));
        #endregion

        #region Removing from inventory
        /*
        if (!_item.Stackable)
        {
            EquipableContainer.Items.Remove(new InventorySlot(_item.Id, _item, _Amount));
            return;
        }
        // if you can only have one object

        for (int i = 0; i < EquipableContainer.Items.Count; i++)
        {
            if (EquipableContainer.Items[i].item.Id == _item.Id)
            {
                EquipableContainer.Items[i].AddAmount(_Amount);
                return;
            }
        }
        EquipableContainer.Items.Add(new InventorySlot(_item.Id, _item, _Amount));
        */

        //container.Items.Add(new InventorySlot(_item.Id, _item, _Amount));



        RemoveItem(Slot, Slot.amount, true);
        #endregion

        ReloadEquipments();
    }

    private void ReloadEquipments()
    {
        for (int i = 0; i < EquipableContainer.Items.Length; i++)
        {

        }
    }

    public void RemoveItem(InventorySlot _item, int _Amount, bool RemoveFromInv)
    {
        if (0 <= _item.amount - _Amount)
        {
            container.Items.Remove(_item);
        }
        else
        {
            _item.amount -= _Amount;
        }

        //if (RemoveFromInv)
        //{
        //    for (int i = 0; i < container.Items.Count; i++)
        //    {
        //        if (container.Items[i].item == _item)
        //        {
        //            container.Items[i].UpdateSlot(-1, null, 0);
        //        }
        //    }
        //}
        //else
        //{
        //    for (int i = 0; i < EquipableContainer.Items.Length; i++)
        //    {
        //        if (EquipableContainer.Items[i].item == _item)
        //        {
        //            EquipableContainer.Items[i].UpdateSlot(-1, null, 0);
        //        }
        //    }
        //}
    }

    [ContextMenu("Save")]
    public void Save()
    {
        /*
        string saveData = JsonUtility.ToJson(this, true);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(string.Concat(Application.persistentDataPath, SavePath));
        bf.Serialize(file, saveData);
        file.Close();
        */

        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(string.Concat(Application.persistentDataPath, SavePath), FileMode.Create, FileAccess.Write);
        formatter.Serialize(stream, container);
        stream.Close();
    }

    [ContextMenu("Load")]
    public void Load()
    {
        if (File.Exists(string.Concat(Application.persistentDataPath, SavePath)))
        {
            /*
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(string.Concat(Application.persistentDataPath, SavePath), FileMode.Open);
            JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
            file.Close();
            */

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(string.Concat(Application.persistentDataPath, SavePath), FileMode.Open, FileAccess.Read);
            container = (Inventory)formatter.Deserialize(stream);
            stream.Close();
        }
    }

    [ContextMenu("Clear")]
    public void Clear()
    {
        container = new Inventory();
        EquipableContainer.Clear();
    }
}


[System.Serializable]
public class Inventory
{
    public List<InventorySlot> Items = new List<InventorySlot>();
}

[System.Serializable]
public class EquipmentInv
{
    public InventorySlot[] Items = new InventorySlot[71];
    // look at item object area AreaOfTheBody for order :D
    public void Clear()
    {
        for (int i = 0; i < Items.Length; i++)
        {
            Items[i].UpdateSlot(-1, new Item(), 0);
        }
    }
}

[System.Serializable]
public class InventorySlot
{
    public int ID = -1;
    public Item item;
    public int amount;
    public InventorySlot(int _ID, Item _item, int _amount)
    {
        ID = _ID;
        item = _item;
        this.amount = _amount;
    }
    public void UpdateSlot(int _ID, Item _item, int _amount)
    {
        ID = _ID;
        item = _item;
        this.amount = _amount;
    }
    public void AddAmount(int Value)
    {
        amount += Value;
    }
}
