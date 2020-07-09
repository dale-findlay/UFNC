using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class WaterBottle : MonoBehaviour {

    public ItemType currentItemType;

    void Start()
    {
        GetComponent<Rigidbody2D>().isKinematic = false;
    }

    public void OnGrabStart()
    {
        Debug.Log("Grabbing." + name);
    }

    public void OnGrabEnd()
    {
        Debug.Log("Done Grabbing." + name);
    }
}
