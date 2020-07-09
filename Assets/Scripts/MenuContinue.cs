using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuContinue : MonoBehaviour {

    public LevelFadeOut levelFadeOut;

    public void OnClick()
    {
        //Check if there are any save games available.

        //PlayerPrefs.GetString("SAVE_COUNT");

        AudioSource musicSource = AudioManager.audioManager.GetSource("intro_music");

        if(musicSource != null)
        {
            AudioManager.audioManager.RemoveFadeOut("intro_music");
        }

        levelFadeOut.fadeComplete += LoadNextLevel;
        levelFadeOut.start = true;

    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene("SC_LEVEL_1");
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
