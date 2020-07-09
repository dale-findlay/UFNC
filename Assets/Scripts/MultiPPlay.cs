using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MultiPPlay : MonoBehaviour {

    public PlayerNamePanel playerNamePanel;
    public LevelFadeOut levelFadeOut;

    public List<Player> gamePlayers = new List<Player>();

    public void OnClick()
    {
        gamePlayers.Clear();
        foreach (InputField field in playerNamePanel.playerNames)
        {
            Player p = new Player();
            p.id = gamePlayers.Count;
            p.name = field.text;

            gamePlayers.Add(p);
        }

        bool load = true;

        foreach(Player p in gamePlayers)
        {
            if(p.name == string.Empty)
            {
                load = false;
            }
        }

        if(load)
        {
            levelFadeOut.start = true;
            levelFadeOut.fadeComplete += LevelEnd;
        }

    }

    public void LevelEnd()
    {
        PlayerManager.playerManager.players = new List<Player>(gamePlayers);
        PlayerManager.playerManager.fullPlayers = new List<Player>(gamePlayers);

        AudioManager.audioManager.RemoveFadeOut("menu-music");

        SceneManager.LoadScene("SC_MULTIP_LEVEL_1");
    }
}
