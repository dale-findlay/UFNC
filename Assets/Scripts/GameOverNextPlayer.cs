using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverNextPlayer : MonoBehaviour {

    public MultiPPlayerChoose playerNext;

    public void OnClick()
    {
        playerNext.gameObject.SetActive(true);
        playerNext.ResetPanel();
        gameObject.SetActive(false);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
