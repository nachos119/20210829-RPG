using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRay : MonoBehaviour
{
    Ray ray;
    RaycastHit rayHit;

    private void Awake()
    {
        ray = new Ray();
        ray.origin = this.transform.position;
        ray.direction = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Physics.Raycast(ray, out rayHit, 15))
        //{
        //    if(rayHit.collider.tag != "Player")
        //    {
        //        rayHit.collider.GetComponent<MeshRenderer>().materials = 
        //    }
        //}
    }
}
