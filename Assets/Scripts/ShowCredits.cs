using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCredits : MonoBehaviour {

    public GameObject creditsScreen;

    public void OnClick()
    {
        if (creditsScreen != null)
        {
            if(creditsScreen.activeInHierarchy)
            {
                creditsScreen.SetActive(false);
            }
            else
            {
                creditsScreen.SetActive(true);
            }

        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
