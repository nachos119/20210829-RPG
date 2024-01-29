using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    // æ∆¿Ã≈€
    [SerializeField] public GameObject item1;
    [SerializeField] public GameObject item2;
    [SerializeField] public GameObject item3;
    [SerializeField] public GameObject item4;
    [SerializeField] public GameObject item5;
    [SerializeField] public GameObject item6;
    [SerializeField] public GameObject item7;

    public void Drop(Vector3 vec)
    {
        int num;
        num = Random.Range(1, 5);

        switch (num)
        {
            case 1:
                Instantiate(item1, vec, Quaternion.Euler(270,180,0));
                break;
            case 2:
                Instantiate(item2, vec, Quaternion.Euler(270, 180, 0));
                break;
            case 3:
                Instantiate(item3, vec, Quaternion.Euler(270, 180, 0));
                break;
            case 4:
                Instantiate(item4, vec, Quaternion.Euler(270, 180, 0));
                break;
        }
    }
}
