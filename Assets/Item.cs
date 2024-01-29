using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum itemType
{
    Equipment,
    Consumables,
    Etc,
    Armor
}

[System.Serializable]
public class Item
{
    public int ID;
    public int Number;
    public itemType itemType;
    public string itemName;
    public Sprite itemImage;
    public List<ItemEffect> efts;

    public bool Use()
    {
        bool isUsed = false;
        foreach(ItemEffect eft in efts)
        {
            isUsed = eft.ExecuteRole();
        }

        return isUsed;
    }

}
