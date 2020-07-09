using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuExit : MonoBehaviour {

    public LevelFadeOut levelFadeOut;

    public void OnClick()
    {
        levelFadeOut.start = true;
        levelFadeOut.fadeComplete += QuitLevel;
    }

    public void QuitLevel()
    {
        Application.Quit();
    }

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
