using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloth : MonoBehaviour, IEquipment
{
    public Item item;
    public SpriteRenderer image;
    public int ID;
    public int Number;

    public bool IActivate => this.gameObject.activeSelf;

    int IEquipment.IID => ID;
    int IEquipment.INumber => Number;
}

