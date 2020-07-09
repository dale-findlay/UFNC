using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuLevel : MonoBehaviour
{
    public AudioClip introMusicClip;
    public LevelFadeIn levelFadeIn;

    // Use this for initialization
    void Start()
    {
        AudioSource introMusic = AudioManager.audioManager.GetSource("intro_music");

        if (introMusic == null)
        {
            introMusic = AudioManager.audioManager.PushSource("intro_music", introMusicClip, true);
            introMusic.Play();
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
