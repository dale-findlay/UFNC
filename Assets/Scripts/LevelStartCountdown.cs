using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelStartCountdown : MonoBehaviour {

    public Text text;
    private float initialCountdownSeconds;
    public float countdownSeconds = 3;
    public List<string> messages = new List<string>();
    public List<AudioClip> audioClips = new List<AudioClip>();

    public bool start = false;

    private Coroutine c = null;

    // Use this for initialization
	void Start ()
    {

        initialCountdownSeconds = countdownSeconds;

        if (start)
        {
            c = StartCoroutine(Countdown());
        }
	}

    public void ResetCountdown()
    {
        countdownSeconds = initialCountdownSeconds;
        c = null;
        start = true;
    }

    private IEnumerator Countdown()
    {
        GameManager.gameManager.enableGrab = false;
        GameManager.gameManager.pauseEnabled = false;
        GameManager.gameManager.startGame = true;
        int i = 0;
        foreach(string message in messages)
        {
            text.text = message;
            string sourceName = "countdown_" + i + 1;
            AudioSource source = AudioManager.audioManager.PushSource(sourceName, audioClips[i]);
            source.Play();
            i++;
            yield return new WaitForSeconds(countdownSeconds / countdownSeconds);
            AudioManager.audioManager.RemoveFadeOut(sourceName);
        }

        gameObject.SetActive(false);
        GameManager.gameManager.enableGrab = true;
        GameManager.gameManager.pauseEnabled = true;
 
        LevelScript.levelScript.hydrationlevel.start = true;
        LevelScript.levelScript.stomachLevel.start = true;
        LevelScript.levelScript.gameTimer.StartTimer();
    }

	// Update is called once per frame
	void Update () {
	
        if(start && c == null)
        {
            c = StartCoroutine(Countdown());
        }

	}
}
