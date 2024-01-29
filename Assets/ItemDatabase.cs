using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;

    public void Awake()
    {
        instance = this;
    }

    public List<Item> ItemDB = new List<Item>();

    

    private void Start()
    {
        
    }
}

