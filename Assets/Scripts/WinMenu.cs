using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinMenu : MonoBehaviour {

    public Player winner;

    public Text playerNameText;
    public Text playerPointsText;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        playerNameText.text = winner.name;
        playerPointsText.text = winner.points.ToString();


    }
}
