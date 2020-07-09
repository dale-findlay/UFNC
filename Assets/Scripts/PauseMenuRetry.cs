using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuRetry : MonoBehaviour {

    public LevelFadeOut levelFadeOut;

    public void OnClick()
    {
        levelFadeOut.start = true;
        levelFadeOut.fadeComplete += OnFadeOut;
    }

    void OnFadeOut()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
