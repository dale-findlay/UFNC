using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MultiPBack : MonoBehaviour {

    public LevelFadeOut levelFadeOut;

    public void OnClick()
    {
        levelFadeOut.start = true;
        levelFadeOut.fadeComplete += FadeComplete;
    }

    public void FadeComplete()
    {
        if (PlayerManager.playerManager)
        {
            Destroy(PlayerManager.playerManager);
            PlayerManager.playerManager = null;
        }

        AudioManager.audioManager.RemoveFadeOut("menu-music");

        SceneManager.LoadScene("SC_MAIN_MENU");
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
