using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMultiplayer : MonoBehaviour {

    public LevelFadeOut levelFadeOut;

	// Use this for initialization
	void Start () {
		
	}

    void FadeComplete()
    {
        SceneManager.LoadScene("SC_MULTIPLAYER");
    }

    public void OnClick()
    {
        AudioManager.audioManager.RemoveFadeOut("intro_music");

        levelFadeOut.start = true;
        levelFadeOut.fadeComplete += FadeComplete;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
