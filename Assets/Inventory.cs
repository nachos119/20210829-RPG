using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IEquipment
{
    int IID { get; }
    int INumber { get; }
    bool IActivate { get; }
}


public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;
    GameObject body;
    public Item emptItem;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;


        body = GameObject.FindGameObjectWithTag("Body");
    }
    #endregion

    public delegate void OnSlotCountChange(int val);    // 대리자 정의
    public OnSlotCountChange onSlotCountChange;         // 대리자 인스턴스화

    public delegate void OnChangeItem();
    public OnChangeItem onChangeItem;

    private int slotCnt;


    public int SlotCnt
    {
        get => slotCnt;
        set
        {
            slotCnt = value;
            onSlotCountChange.Invoke(slotCnt);
        }
    }


    public List<Item> items = new List<Item>();

    private void Start()
    {
        SlotCnt = 40;
    }


    public bool AddItem(Item _item)
    {
        if (items.Count < SlotCnt)
        {
            items.Add(_item);
            if (onChangeItem != null)
                onChangeItem.Invoke();

            return true;
        }
        return false;
    }

    public void RemoveItem(int _index)
    {
        items.RemoveAt(_index);
        onChangeItem.Invoke();
    }


    public void InItem(FieldItems fieldItems)
    {
        if (AddItem(fieldItems.GetItem()))
            fieldItems.DestroyItem();
    }

    public void ExchangeItem(int _index)
    {
        for (int i = 0; i < body.transform.childCount; i++)
        {
            if (body.transform.GetChild(i).gameObject.GetComponent<EquipmentPlayer>() != null)
            {
                int num = body.transform.GetChild(i).gameObject.GetComponent<EquipmentPlayer>().part;
                if (num == items[_index].ID)
                {

                    var equip = body.transform.GetChild(i).gameObject.GetComponent<EquipmentPlayer>();

                    emptItem.ID = equip.item.ID;
                    emptItem.Number = equip.item.Number;
                    emptItem.itemName = equip.item.itemName;
                    emptItem.itemImage = equip.item.itemImage;
                    emptItem.itemType = equip.item.itemType;

                    equip.item.ID = items[_index].ID;
                    equip.item.Number = items[_index].Number;
                    equip.item.itemName = items[_index].itemName;
                    equip.item.itemImage = items[_index].itemImage;
                    equip.item.itemType = items[_index].itemType;

                    items[_index].ID = emptItem.ID;
                    items[_index].Number = emptItem.Number;
                    items[_index].itemName = emptItem.itemName;
                    items[_index].itemImage = emptItem.itemImage;
                    items[_index].itemType = emptItem.itemType;

                    equip.ImageChange();

                    break;
                }
            }
        }

    }
}
