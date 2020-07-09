using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiPGameOverPanel : MonoBehaviour {

    public GameObject retryButton;
    public GameObject continueButton;

    // Update is called once per frame
	void Update () {
		
        if(PlayerManager.playerManager.players.Count == 0)
        {
            retryButton.SetActive(false);
            continueButton.SetActive(true);
        }
        else
        {
            retryButton.SetActive(true);
        }
	}
}
