using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerLevelScript : MonoBehaviour {

    public AudioClip menuMusicClip;

    public string musicName = "menu-music";

	// Use this for initialization
	void Start () {

        AudioManager.audioManager.RemoveFadeOut("level_music");

        AudioSource source = AudioManager.audioManager.PushSource(musicName, menuMusicClip, true);
        source.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
