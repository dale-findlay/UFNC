using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiPPlayerChoose : MonoBehaviour {

    public Text choiceText;
    public TextRotation playerName;

    public GameTimer timer;
    public HydrationLevel hydration;
    public StomachLevel stomach;
    public NoodleCounter noodleCounter;
    public NoodleBoxController noodleController;

    public LevelStartCountdown countDown;
    public GameObject gameOverMenu;

    public void ResetPanel()
    {
        playButton.SetActive(false);
        gameOverMenu.SetActive(false);

        playerName.rotate = true;

        timer.Reset();
        hydration.Reset();
        stomach.Reset();
        noodleCounter.Reset();
        noodleController.Clear();

        //set the playerText to the next player.
        Player p = PlayerManager.playerManager.GetRandomPlayerNotPlayed();

        playerName.GetComponent<Text>().text = p.name;

        MultiPGameManager.gameManager.currentPlayer = p;

        StartCoroutine(RevealPlayerName());
    }

    public float revealWaitTime = 3.0f;

    public GameObject playButton;

    // Use this for initialization
    void Start () {

        playButton.SetActive(false);

        //set the playerText to the next player.
        Player p = PlayerManager.playerManager.GetRandomPlayerNotPlayed();

        playerName.GetComponent<Text>().text = p.name;

        MultiPGameManager.gameManager.currentPlayer = p;

        StartCoroutine(RevealPlayerName());

    }
    
    private IEnumerator RevealPlayerName()
    {
        yield return new WaitForSeconds(revealWaitTime);
        playerName.rotate = false;
        yield return new WaitForSeconds(0.5f);
        playButton.SetActive(true);
    }

    // Update is called once per frame
    void Update () {
		


	}
}
