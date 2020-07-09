using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Profiler : MonoBehaviour
{

    public static Profiler profiler;
    public Text fpsText;
    public Text noodleCountDisplayText;
    public Text noodleCountText;

    public string playerNotationTemplate = "Name: \"_NAME_\"  | Points : {_POINTS_}";
    public Transform playerStatPanelPrefab;
    public float yOffset;

    [HideInInspector]
    public int noodleCount;

    //list independent of playermanagers list.
    List<ProfilerPlayer> gamePlayers = new List<ProfilerPlayer>();

    private float deltaTime = 0.0f;

    private void Awake()
    {
        if (profiler)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            profiler = this;
            DontDestroyOnLoad(this);
        }
    }

    struct ProfilerPlayer
    {
        public Player p;
        public GameObject textObject;
    }

    // Use this for initialization
    void Start()
    {

        if (PlayerManager.playerManager)
        {
            //Show multiplayer stats.

            foreach (Player player in PlayerManager.playerManager.fullPlayers)
            {
                ProfilerPlayer p = new ProfilerPlayer();
                p.p = player;

                if (gamePlayers.Count > 0)
                {
                    Vector3 newPos = gamePlayers[gamePlayers.Count - 1].textObject.transform.position;
                    newPos.y -= yOffset;

                    p.textObject = Instantiate(playerStatPanelPrefab, newPos, Quaternion.identity, gameObject.transform).gameObject;

                    string playerRepresentation = playerNotationTemplate;
                    playerRepresentation = playerRepresentation.Replace("_NAME_", player.name);
                    playerRepresentation = playerRepresentation.Replace("_POINTS_", player.points.ToString());


                    p.textObject.GetComponent<Text>().text = playerRepresentation;
                }
                else
                {
                    Vector3 newPos = noodleCountDisplayText.transform.position;
                    newPos.y -= yOffset;

                    p.textObject = Instantiate(playerStatPanelPrefab, newPos, Quaternion.identity, gameObject.transform).gameObject;

                    string playerRepresentation = playerNotationTemplate;
                    playerRepresentation = playerRepresentation.Replace("_NAME_", player.name);
                    playerRepresentation = playerRepresentation.Replace("_POINTS_", player.points.ToString());


                    p.textObject.GetComponent<Text>().text = playerRepresentation;
                }


                gamePlayers.Add(p);
            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        deltaTime += Time.deltaTime;
        deltaTime /= 2.0f;
        float fps = 1.0f / deltaTime;

        fpsText.text = fps + " FPS";

        noodleCountText.text = noodleCount.ToString();

        if (PlayerManager.playerManager)
        {
            Debug.Log(PlayerManager.playerManager.fullPlayers.Count);
            for (int i = 0; i < PlayerManager.playerManager.fullPlayers.Count; ++i)
            {
                string playerRepresentation = playerNotationTemplate;
                playerRepresentation = playerRepresentation.Replace("_NAME_", PlayerManager.playerManager.fullPlayers[i].name);
                playerRepresentation = playerRepresentation.Replace("_POINTS_", PlayerManager.playerManager.fullPlayers[i].points.ToString());

                Debug.Log(gamePlayers.Count);
                
                gamePlayers[i].textObject.GetComponent<Text>().text = playerRepresentation;
            }
        }

    }
}
