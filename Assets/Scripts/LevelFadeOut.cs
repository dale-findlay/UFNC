using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFadeOut : MonoBehaviour {

    public List<FadeOut> fadeOutItems = new List<FadeOut>();

    public bool start = false;
    public delegate void FadeOutFinishAction();
    public event FadeOutFinishAction fadeComplete;
    public bool done = false;

    private void Update()
    {

        if (start)
        {
            if (GetComponent<LevelFadeIn>())
            {
                GetComponent<LevelFadeIn>().Freeze();
            }

            foreach(FadeOut fadeOut in fadeOutItems)
            {
                fadeOut.enabled = true;
                fadeOut.start = true;

                done = fadeOut.done;
            }
        }

        if(done)
        {
            fadeComplete();
        }
    }

}
