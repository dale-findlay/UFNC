using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiPGameManager : MonoBehaviour {

    public static MultiPGameManager gameManager;
    public Player currentPlayer;
    public GameObject playerNext;

    private void Awake()
    {
        if (gameManager)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            gameManager = this;
            DontDestroyOnLoad(this);
        }
    }

    // Use this for initialization
    void Start () {
        if(playerNext != null)
        {
            playerNext.SetActive(true);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
