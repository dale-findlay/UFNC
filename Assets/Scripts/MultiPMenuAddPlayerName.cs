using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiPMenuAddPlayerName : MonoBehaviour {

    public PlayerNamePanel playerNamePanel;

    public void OnClick()
    {
        playerNamePanel.AddPlayerNameField();
    }
}
