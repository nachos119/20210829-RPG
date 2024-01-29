using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monset : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "RWeapon")
        {
            gameObject.GetComponent<ItemDrop>().Drop(transform.position);
            this.transform.gameObject.SetActive(false);
        }
    }
}
