using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroCard : MonoBehaviour {

    public List<FadeInOut> introCards = new List<FadeInOut>();
    public AudioClip introSound;

	// Use this for initialization
	void Start () {
        StartCoroutine(WaitForIntroCards());
	}

    private void Awake()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    public IEnumerator WaitForIntroCards()
    {
        AudioSource introSource = AudioManager.audioManager.PushSource("intro_music", introSound, true);
        introSource.Play();

        foreach(FadeInOut fade in introCards)
        {
            fade.start = true;
            yield return new WaitForSeconds(fade.fadeInTime + fade.fadeOutTime);

        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
	
	// Update is called once per frame
	void Update () {

	}
}
