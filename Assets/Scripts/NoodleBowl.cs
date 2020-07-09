//Script: NoodleBowl.cs
//Usage: Handles moving the noodle across the conveyor belt.


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoodleBowl : MonoBehaviour
{
    [SerializeField]
    public bool moveRight = true;
    public ItemType currentNoodleType;

    public void DestroyNoodle()
    {
        Destroy(gameObject);
        //Profiler.profiler.noodleCount--;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Conveyor")
        {
            moveRight = true;
        }
        else if (collision.gameObject.GetComponent<NoodleBowl>() != null)
        {
            moveRight = true;
        }
        else
        {
            moveRight = false;
        }
    }

    public void OnGrabStart()
    {
        //Debug.Log("Grabbing." + name);
        moveRight = false;
        GetComponent<Rigidbody2D>().isKinematic = true;
    }

    public void OnGrabEnd()
    {
        //Debug.Log("Done Grabbing." + name);
        moveRight = true;
        GetComponent<Rigidbody2D>().isKinematic = false;
    }

    void Update()
    {
        if (transform.position.y < -7)
        {
            DestroyNoodle();
        }
    }

    void FixedUpdate()
    {
        if (moveRight)
        {
            if (GameObject.Find("MoveTarget") != null)
            {
                //Debug.Log("Moving IN!");
                transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("MoveTarget").transform.position, Time.deltaTime * GameManager.gameManager.conveyorSpeed);
            }
            else
            {
                moveRight = false;
            }

        }
    }
}
