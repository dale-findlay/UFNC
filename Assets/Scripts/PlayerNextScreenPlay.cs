using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNextScreenPlay : MonoBehaviour {

    public LevelStartCountdown countDown;
    public NoodleBoxController noodleBoxController;

    public void OnClick()
    {
        countDown.gameObject.SetActive(true);
        countDown.ResetCountdown();

        transform.parent.gameObject.SetActive(false);

        noodleBoxController.StartNoodleBoxes();
    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
