using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestDemo : MonoBehaviour 
{

    //This script goes on the ChestComplete prefab;

    public Animator chestAnim; //Animator for the chest;

    bool col;
    bool open;

    // Use this for initialization
    void Awake ()
    {
        //get the Animator component from the chest;
        chestAnim = GetComponent<Animator>();
        //start opening and closing the chest for demo purposes;
        //StartCoroutine(OpenCloseChest());
        col = false;
        open = false;

    }


    //IEnumerator OpenCloseChest()
    //{
    //    //play open animation;
    //    chestAnim.SetTrigger("open");
    //    //wait 2 seconds;
    //    yield return new WaitForSeconds(2);
    //    //play close animation;
    //    chestAnim.SetTrigger("close");
    //    //wait 2 seconds;
    //    yield return new WaitForSeconds(2);
    //    //Do it again;
    //    StartCoroutine(OpenCloseChest());

    //}

    private void Update()
    {
        if (col)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                chestAnim.SetTrigger("open");
                open = true;
            }
        }

        if (open)
        {
            StartCoroutine(OpenCloseChest());
        }
    }

    IEnumerator OpenCloseChest()
    {
        yield return new WaitForSeconds(2);
        gameObject.GetComponent<ItemDrop>().Drop(transform.position);
        this.transform.gameObject.SetActive(false);
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
        }
    }
}
