using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverStats : MonoBehaviour {

    public NoodleCounter noodleCounter;
    public Text noodlesEaten;
    public Text pointsAwarded;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        noodlesEaten.text = noodleCounter.noodleCount.ToString();

        if(MultiPGameManager.gameManager)
        {
            pointsAwarded.text = MultiPGameManager.gameManager.currentPlayer.points.ToString();
        }
        else
        {
            pointsAwarded.text = GameManager.gameManager.currentPlayer.points.ToString();
        }
    }
}
