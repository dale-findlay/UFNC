using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MultiPContinue : MonoBehaviour {

    public LevelFadeOut levelFadeOut;

    public void OnClick()
    {
        levelFadeOut.start = true;
        levelFadeOut.fadeComplete += FadeComplete;
    }

	void FadeComplete()
    {
        SceneManager.LoadScene("MP_FINISH");	
	}
}
