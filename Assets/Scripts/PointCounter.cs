using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour {

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(MultiPGameManager.gameManager)
        {
            GetComponent<Text>().text = MultiPGameManager.gameManager.currentPlayer.points.ToString();
        }
        else
        {
            GetComponent<Text>().text = GameManager.gameManager.currentPlayer.points.ToString();
        }


    }
}
