using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MPFinishMainMenu : MonoBehaviour {

    public LevelFadeOut levelFadeOut;

    public void OnClick()
    {
        levelFadeOut.gameObject.SetActive(true);
        levelFadeOut.start = true;
        levelFadeOut.fadeComplete += FadeComplete;
    }
		
    public void FadeComplete()
    {
        Debug.Log("Loading Menu...");
        SceneManager.LoadScene("SC_MAIN_MENU");
    }

	// Update is called once per frame
	void Update () {
		
	}
}
