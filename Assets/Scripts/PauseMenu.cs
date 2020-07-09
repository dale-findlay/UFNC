using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    private bool paused = false;

    public GameObject pauseMenu;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        if (GameManager.gameManager.pauseEnabled)
        {
            if (!paused)
            {
                //Open the pause menu
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                //Close the pause menu.
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
            }

            paused = !paused;
        }
    }
}
