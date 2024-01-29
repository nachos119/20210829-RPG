using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldItems : MonoBehaviour
{
    public Item item;
    public SpriteRenderer image;
    Rigidbody rigidbody;
    Vector3 tempPosition;
    bool ground;

    public void SetItem(Item _item)
    {
        item.ID = _item.ID;
        item.Number = _item.Number;
        item.itemName = _item.itemName;
        item.itemImage = _item.itemImage;
        item.itemType = _item.itemType;
        item.efts = _item.efts;

        image.sprite = item.itemImage;
    }

    public Item GetItem()
    {
        return item;
    }

    public void DestroyItem()
    {
        Destroy(gameObject);
    }

    private void Awake()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        ground = false;
    }

    private void Start()
    {
        tempPosition = transform.position;
        rigidbody.MovePosition(transform.position + Vector3.up);
        StartCoroutine(Position());
    }

    IEnumerator Position()
    {
        yield return new WaitForSeconds(0.5f);
        this.GetComponent<Rigidbody>().isKinematic = true;
        this.transform.position = tempPosition;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //        Inventory.instance.InItem(this);
    //}

    private void OnTrigger(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                Inventory.instance.InItem(this);
            }
        }
    }
}
