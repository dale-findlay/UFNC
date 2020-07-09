using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuExit : MonoBehaviour {

    public LevelFadeOut levelFadeOut;

    public void OnClick()
    {
        Time.timeScale = 1;
        AudioManager.audioManager.RemoveFadeOut("level_music");

        levelFadeOut.start = true;
        levelFadeOut.fadeComplete += LoadNextLevel;
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene("SC_MAIN_MENU");
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
