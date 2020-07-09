using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPauseExit : MonoBehaviour {

    public void OnClick()
    {
        SceneManager.LoadScene("SC_MAIN_MENU");
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
