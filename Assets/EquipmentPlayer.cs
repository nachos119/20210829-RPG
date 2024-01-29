using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EquipmentPlayer : MonoBehaviour
{
    GameObject player;
    GameObject equip;
    GameObject now;

    public Item item;
    public Image itemIcon;
    public int part;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        //string tag = this.gameObject.tag;
        if (1 == part)
            Armor();
    }

    public void Armor()
    {
        GameObject equip = player.transform.GetChild(1).gameObject;
        for (int i = 0; i < equip.transform.childCount; i++)
        {
            if (equip.transform.GetChild(i).gameObject.GetComponent<Cloth>().IActivate == true)
            {
                item.ID = equip.transform.GetChild(i).gameObject.GetComponent<Cloth>().ID;
                item.Number = equip.transform.GetChild(i).gameObject.GetComponent<Cloth>().Number;
                item.itemName = equip.transform.GetChild(i).gameObject.GetComponent<Cloth>().item.itemName;
                item.itemImage = equip.transform.GetChild(i).gameObject.GetComponent<Cloth>().item.itemImage;
                item.itemType = equip.transform.GetChild(i).gameObject.GetComponent<Cloth>().item.itemType;
                break;
            }
        }

        this.transform.GetChild(0).GetComponent<Image>().enabled = true;
        itemIcon.sprite = item.itemImage;
        itemIcon.gameObject.SetActive(true);
    }

    public void ImageChange()
    {
        GameObject parts = player.transform.GetChild(item.ID).gameObject;
        for (int i = 0; i < parts.transform.childCount; i++)
        {
            if (parts.transform.GetChild(i).gameObject.GetComponent<Cloth>().IActivate == true)
            {
                parts.transform.GetChild(i).gameObject.SetActive(false);
                break;
            }
        }

        for (int i = 0; i < parts.transform.childCount; i++)
        {
            if (parts.transform.GetChild(i).gameObject.GetComponent<Cloth>().item.Number == item.Number)
            {
                parts.transform.GetChild(i).gameObject.SetActive(true);
                break;
            }
        }

        itemIcon.sprite = item.itemImage;
        itemIcon.gameObject.SetActive(true);
    }
}
