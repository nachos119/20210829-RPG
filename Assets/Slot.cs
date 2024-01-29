using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerUpHandler
{
    public int slotnum;
    public Item item;
    public Image itemIcon;

    bool Click = false; //Ŭ�� ����
    float ClickWaitTime = 0.0f; //Ŭ�� ���ð�
    float dblClickSpeed = 0.5f; //���� Ŭ�� �ӵ�

    public void UpdateSlotUI()
    {
        transform.GetChild(0).GetComponent<Image>().enabled = true;
        itemIcon.sprite = item.itemImage;
        itemIcon.gameObject.SetActive(true);
    }

    public void RemoveSlot()
    {
        item = null;
        itemIcon.gameObject.SetActive(false);
        //transform.GetChild(0).GetComponent<Image>().enabled = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
        if (Click)
        {
            //����Ŭ�� �̺�Ʈ ó��

            Debug.Log("dbl click!");
            //bool isUse = item.Use();
            //if (isUse)
            //{
            //    //Inventory.instance.RemoveItem(slotnum);


            //}
            Inventory.instance.ExchangeItem(slotnum);
            UpdateSlotUI();
            Click = false;
        }
        else
        {

            ClickWaitTime = Time.time; //Ŭ�� �������� �ð� ����
            Click = true;

            Debug.Log("click! = " + Click);
        }
    }

    private void Update()
    {
        if (Click)
        {
            if (Time.time > ClickWaitTime + dblClickSpeed)
            {
                Debug.Log("click ini");
                Click = false;
            }
        }
    }
}
