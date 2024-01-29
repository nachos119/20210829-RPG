using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public delegate void OnShopCountChange(int val);
    public OnShopCountChange onShopCountChange;

    private int shopSlotCnt;

    bool col;

    GameObject UI;

    public int ShopSlotCnt
    {
        get => shopSlotCnt;
        set
        {
            shopSlotCnt = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        shopSlotCnt = 4;
        col = false;
        UI = GameObject.FindWithTag("UI");
    }

    private void Update()
    {
        if (col)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                UI.GetComponent<InventoryUI>().activeShop = true;
                UI.GetComponent<InventoryUI>().shopPanel.SetActive(UI.GetComponent<InventoryUI>().activeShop);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            col = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            col = false;
            if (UI.GetComponent<InventoryUI>().activeShop)
            {
                UI.GetComponent<InventoryUI>().activeShop = false;
                UI.GetComponent<InventoryUI>().shopPanel.SetActive(UI.GetComponent<InventoryUI>().activeShop);
            }
        }
    }
}
