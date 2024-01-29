using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    //// 싱글톤
    //public static ObjectPool Instance;

    //// 몬스터
    //[SerializeField] private GameObject monster1;
    //Queue<GameObject> monster1Queue = new Queue<GameObject>();
    //[SerializeField] private GameObject monster2;
    //Queue<GameObject> monster2Queue = new Queue<GameObject>();

    //// 아이템
    //[SerializeField] public GameObject item1;
    //Queue<GameObject> item1Queue = new Queue<GameObject>();
    //[SerializeField] public GameObject item2;
    //Queue<GameObject> item2Queue = new Queue<GameObject>();
    //[SerializeField] public GameObject item3;
    //Queue<GameObject> item3Queue = new Queue<GameObject>();
    //[SerializeField] public GameObject item4;
    //Queue<GameObject> item4Queue = new Queue<GameObject>();
    //[SerializeField] public GameObject item5;
    //Queue<GameObject> item5Queue = new Queue<GameObject>();
    //[SerializeField] public GameObject item6;
    //Queue<GameObject> item6Queue = new Queue<GameObject>();
    //[SerializeField] public GameObject item7;
    //Queue<GameObject> item7Queue = new Queue<GameObject>();


    //private void Awake()
    //{ 
    //    Instance = this; 
    //    Initialize(3); 
    //}

    //private void Initialize(int initCount) 
    //{ 
    //    for (int i = 0; i < initCount; i++)
    //    {
    //        monster1Queue.Enqueue(CreateMonster1Object());
    //        monster2Queue.Enqueue(CreateMonster2Object());
    //        item1Queue.Enqueue(CreateItem1Object());
    //        item2Queue.Enqueue(CreateItem2Object());
    //        item3Queue.Enqueue(CreateItem3Object());
    //        item4Queue.Enqueue(CreateItem4Object());
    //        item5Queue.Enqueue(CreateItem5Object());
    //        item6Queue.Enqueue(CreateItem6Object());
    //        item7Queue.Enqueue(CreateItem7Object());
    //    } 
    //}
    //#region Monster
    //// 몬스터
    //private GameObject CreateMonster1Object()
    //{
    //    var newObj = Instantiate(monster1); 
    //    newObj.gameObject.SetActive(false); 
    //    newObj.transform.SetParent(transform); 
    //    return newObj; 
    //}

    //private GameObject CreateMonster2Object()
    //{
    //    var newObj = Instantiate(monster2);
    //    newObj.gameObject.SetActive(false);
    //    newObj.transform.SetParent(transform);
    //    return newObj;
    //}
    //#endregion
    //#region Item
    //// 아이템
    //private GameObject CreateItem1Object()
    //{
    //    var newObj = Instantiate(item1);
    //    newObj.gameObject.SetActive(false);
    //    newObj.transform.SetParent(transform);
    //    return newObj;
    //}

    //private GameObject CreateItem2Object()
    //{
    //    var newObj = Instantiate(item2);
    //    newObj.gameObject.SetActive(false);
    //    newObj.transform.SetParent(transform);
    //    return newObj;
    //}

    //private GameObject CreateItem3Object()
    //{
    //    var newObj = Instantiate(item3);
    //    newObj.gameObject.SetActive(false);
    //    newObj.transform.SetParent(transform);
    //    return newObj;
    //}
    //private GameObject CreateItem4Object()
    //{
    //    var newObj = Instantiate(item4);
    //    newObj.gameObject.SetActive(false);
    //    newObj.transform.SetParent(transform);
    //    return newObj;
    //}
    //private GameObject CreateItem5Object()
    //{
    //    var newObj = Instantiate(item5);
    //    newObj.gameObject.SetActive(false);
    //    newObj.transform.SetParent(transform);
    //    return newObj;
    //}
    //private GameObject CreateItem6Object()
    //{
    //    var newObj = Instantiate(item6);
    //    newObj.gameObject.SetActive(false);
    //    newObj.transform.SetParent(transform);
    //    return newObj;
    //}
    //private GameObject CreateItem7Object()
    //{
    //    var newObj = Instantiate(item7);
    //    newObj.gameObject.SetActive(false);
    //    newObj.transform.SetParent(transform);
    //    return newObj;
    //}
    //#endregion

    //public static GameObject GetObject() 
    //{
    //    if (Instance.poolingObjectQueue.Count > 0) 
    //    { 
    //        var obj = Instance.poolingObjectQueue.Dequeue(); 
    //        obj.transform.SetParent(null); 
    //        obj.gameObject.SetActive(true); 
    //        return obj; 
    //    } 
    //    else
    //    { 
    //        var newObj = Instance.CreateNewObject();
    //        newObj.gameObject.SetActive(true);
    //        newObj.transform.SetParent(null); 
    //        return newObj;
    //    } 
    //}

    //public static void ReturnObject(GameObject obj)
    //{
    //    switch(obj.tag)
    //    {
    //        case "Monster":
    //            break;

    //        case "Item":
    //            break;
    //    }
    //    obj.gameObject.SetActive(false);
    //    obj.transform.SetParent(Instance.transform); 
    //    Instance.poolingObjectQueue.Enqueue(obj);
    //}

}
