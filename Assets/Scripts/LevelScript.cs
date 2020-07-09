using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{
    public static LevelScript levelScript;

    public AudioClip levelMusicClip;
    public MenuSpeaker menuSpeaker;

    public StomachLevel stomachLevel;
    public HydrationLevel hydrationlevel;
    public GameTimer gameTimer;
    public NoodleBoxController noodleBoxController;
    public LevelStartCountdown countdown;

    public GameObject gameOverMenu;
    public GameObject fadeInOut;

    private void Awake()
    {
        levelScript = this;

        fadeInOut.SetActive(true);
        gameOverMenu.SetActive(false);
    }

    // Use this for initialization
    void Start()
    {
        GameManager.gameManager.enableGrab = false;
        AudioSource levelMusic = AudioManager.audioManager.GetSource("level_music");

        if (levelMusic == null)
        {
            levelMusic = AudioManager.audioManager.PushSource("level_music", levelMusicClip, true);
        }

        levelMusic.Play();

        menuSpeaker.muted = AudioManager.audioManager.muted;

        if (!MultiPGameManager.gameManager)
        {
            GameManager.gameManager.currentPlayer = new Player();
            countdown.start = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Lose conditions.
        if (stomachLevel.gameOver || hydrationlevel.gameOver || gameTimer.gameOver)
        {
            if (gameOverMenu.activeInHierarchy == false)
            {
                //Debug.Log("Setting");
                GameManager.gameManager.enableGrab = false;
                noodleBoxController.Stop();
                gameTimer.StopTimer();
                stomachLevel.start = false;
                hydrationlevel.start = false;
                gameOverMenu.SetActive(true);
            }
        }
    }
}
