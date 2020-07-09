using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFadeIn : MonoBehaviour {

    public List<FadeIn> fadeInItems = new List<FadeIn>();
    public bool done = false;

    void Start()
    {
        
    }

    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    public void Freeze()
    {
        foreach (FadeIn fadeIn in fadeInItems)
        {
            fadeIn.enabled = false;
        }
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode sceneMode)
    {
        foreach(FadeIn fadeIn in fadeInItems)
        {
            fadeIn.start = true;

            if(fadeIn.done)
            {
                fadeIn.enabled = false;
                done = true;
            }
            else
            {
                done = false;
            }
        }

        if(done)
        {
            enabled = false;
        }
    }

}
