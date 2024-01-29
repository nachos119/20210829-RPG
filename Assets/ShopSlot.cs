using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour, IPointerUpHandler
{
    public Item item;


    // Start is called before the first frame update
    void Awake()
    {
        Text textObj = gameObject.transform.parent.GetChild(1).GetComponent<Text>();
        textObj.text = item.itemName;
        Image imageObj = gameObject.transform.parent.GetChild(2).GetComponent<Image>();
        imageObj.sprite = item.itemImage;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Inventory.instance.AddItem(item);
    }
}
