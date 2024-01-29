using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    Inventory inven;

    public GameObject inventoryPanel;
    bool activeInventory = false;

    public GameObject equipmentPanel;
    bool activeEquipment = false;


    public Slot[] slots;
    public Transform slotHolder;

    // 상점
    GameObject shop;
    public ShopSlot[] shopSlots;
    public Transform shopHolder;
    public GameObject shopPanel;
    public bool activeShop = false;


    private void Start()
    {
        inven = Inventory.instance;
        
        slots = slotHolder.GetComponentsInChildren<Slot>();

        inven.onSlotCountChange += SlotChange;

        inven.onChangeItem += RedrawSlotUI;

        inventoryPanel.SetActive(activeInventory);
        equipmentPanel.SetActive(activeEquipment);

        // 상점
        shop = GameObject.FindWithTag("Shop");
        shop.GetComponent<Shop>().onShopCountChange += ShopChange;
        shopSlots = shopHolder.GetComponentsInChildren<ShopSlot>();
        shopPanel.SetActive(activeShop);
    }

    private void ShopChange(int val)
    {
        for (int i = 0; i < shopSlots.Length; i++)
        {
            if (i < shop.GetComponent<Shop>().ShopSlotCnt)
            {
                shopSlots[i].gameObject.SetActive(true);
            }
            else
            {
                shopSlots[i].gameObject.SetActive(false);
            }
        }
    }

    private void SlotChange(int val)
    {
        for(int i = 0; i < slots.Length; i++)
        {
            slots[i].slotnum = i;

            if (i < inven.SlotCnt)
                slots[i].GetComponent<Button>().interactable = true;
            else
                slots[i].GetComponent<Button>().interactable = false;

        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            activeInventory = !activeInventory;
            inventoryPanel.SetActive(activeInventory);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            activeEquipment = !activeEquipment;
            equipmentPanel.SetActive(activeEquipment);
        }

        if(activeShop)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                activeShop = false;
                shopPanel.SetActive(activeShop);
            }
        }
    }

    void RedrawSlotUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].RemoveSlot();
        }
        for (int i = 0; i < inven.items.Count; i++)
        {
            slots[i].item = inven.items[i];
            slots[i].UpdateSlotUI();
        }
    }

    public void AddSlot()
    {
        inven.SlotCnt = inven.SlotCnt + 4;
    }

}
