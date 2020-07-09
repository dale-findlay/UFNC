using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Player
{
    public int id;
    public string name;
    public int points;
}

public class PlayerManager : MonoBehaviour
{

    public static PlayerManager playerManager;

    public List<Player> fullPlayers = new List<Player>();
    public List<Player> players = new List<Player>();
    public List<Player> playedPlayers = new List<Player>();


    // Use this for initialization
    void Awake()
    {
        if (playerManager)
        {
            DestroyImmediate(this);
        }
        else
        {
            playerManager = this;
            DontDestroyOnLoad(this);
        }

    }

    public Player GetRandomPlayerNotPlayed()
    {
        int index = UnityEngine.Random.Range(0, players.Count - 1);

        Player p = players[index];

        players.Remove(p);
        playedPlayers.Add(p);

        return p;
    }

    // Update is called once per frame
    void Update()
    {
        if (MultiPGameManager.gameManager && fullPlayers.Count > 0)
        {
            Player p = fullPlayers[MultiPGameManager.gameManager.currentPlayer.id];
            p.points = MultiPGameManager.gameManager.currentPlayer.points;

            fullPlayers[MultiPGameManager.gameManager.currentPlayer.id] = p;

        }

    }
}
