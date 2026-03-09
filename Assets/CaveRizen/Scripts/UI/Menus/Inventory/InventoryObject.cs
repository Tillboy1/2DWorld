using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;
using System.Runtime.Serialization;

[CreateAssetMenu(fileName = "InventoryObject", menuName = "Scriptable Objects/InventoryObject")]
public class InventoryObject : ScriptableObject
{
    public string SavePath;
    public ItemDatabaseObject database;
    public Inventory container;


    // equipment spaces in EquipmentInv for the array size

    public float CurrentWeight, MaxWeight;

    public void AddItem(Item _item, int _Amount)
    {
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
