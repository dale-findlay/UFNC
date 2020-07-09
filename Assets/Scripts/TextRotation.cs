using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextRotation : MonoBehaviour {

    public float speed = 1000f;
    public float returnSpeed = 500f;

    public bool rotate = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(rotate)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + Time.deltaTime * speed);
        }
        else if(!rotate && transform.eulerAngles.z != 0)
        {
            transform.eulerAngles = Vector3.MoveTowards(transform.eulerAngles, Vector3.zero, Time.deltaTime * returnSpeed);
        }
	}
}
