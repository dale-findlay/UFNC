using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishLevel : MonoBehaviour
{
    [System.Serializable]
    public struct Segment
    {
        //public int index;
        public Transform prefab;
        public Text text;
    }
    public WinMenu winMenu;

    [Header("Segments")]
    public Segment max;
    public Segment min;


    public List<Segment> segments = new List<Segment>();

    private bool skipped = false;

    Coroutine c = null;

    // Use this for initialization
    void Start()
    {
        c = StartCoroutine(WaitForSegments());
    }

    private IEnumerator WaitForSegments()
    {
        List<Player> points = new List<Player>();

        foreach (Player p in PlayerManager.playerManager.fullPlayers)
        {
            points.Add(p);
        }

        Player minPoints = points[0];
        Player maxPoints = points[0];

        for (int i = 0; i < points.Count; ++i)
        {
            if (points[i].points > maxPoints.points)
            {
                maxPoints = points[i];
                continue;
            }

            if (points[i].points < minPoints.points)
            {
                minPoints = points[i];
                continue;
            }
        }

        //points.Remove(minPoints);
        //points.Remove(maxPoints);

        List<Player> players = new List<Player>();

        foreach (Player p in points)
        {
            if (p.Equals(minPoints) || p.Equals(maxPoints))
            {
                continue;
            }
            else
            {
                players.Add(p);
            }
        }


        players.Sort();

        List<Segment> segmentsToShow = new List<Segment>();

        max.text.text = maxPoints.name;
        segmentsToShow.Add(max);
        min.text.text = minPoints.name;
        segmentsToShow.Add(min);

        foreach (Player p in players)
        {
            Segment segment = new Segment();
            segment.prefab = segments[segmentsToShow.Count].prefab;
            segment.text = segments[segmentsToShow.Count].text;
            segment.text.text = p.name;

            segmentsToShow.Add(segment);
        }

        foreach (Segment s in segmentsToShow)
        {
            GameObject newSegment = Instantiate(s.prefab, s.prefab.position, Quaternion.identity).gameObject;

            NoodleBox b = newSegment.GetComponentInChildren<NoodleBox>();

            if (!skipped)
            {
                if (b != null)
                {
                    s.text.gameObject.SetActive(true);
                    yield return new WaitForSeconds(b.waitTime * b.noodleSpawnLimit);
                }
            }
            else
            {
                s.text.gameObject.SetActive(true);
            }
        }

        winMenu.winner = maxPoints;
        winMenu.gameObject.SetActive(true);

        Destroy(PlayerManager.playerManager.gameObject);
        PlayerManager.playerManager = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (InputHandler.GetScreenPressDown(0))
        {
            skipped = true;
        }

        Debug.Log(c);
    }
}
