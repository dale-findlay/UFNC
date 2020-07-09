using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiPMenuRemovePlayerName : MonoBehaviour
{

    public PlayerNamePanel playerNamePanel;

    public void OnClick()
    {
        if (playerNamePanel.playerNames.Count > 2)
        {
            GameObject field = playerNamePanel.playerNames[playerNamePanel.playerNames.Count - 1].gameObject;
            playerNamePanel.playerNames.Remove(field.GetComponent<InputField>());
            Destroy(field);
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
