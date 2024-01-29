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

    bool Click = false; //클릭 여부
    float ClickWaitTime = 0.0f; //클릭 대기시간
    float dblClickSpeed = 0.5f; //더블 클릭 속도

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
            //더블클릭 이벤트 처리

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

            ClickWaitTime = Time.time; //클릭 했을때의 시간 저장
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
