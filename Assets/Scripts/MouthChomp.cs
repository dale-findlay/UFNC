using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthChomp : MonoBehaviour {

    public Sprite mouthOpen;
    public Sprite mouthClosed;

    public AudioClip chompSoundEffect;

    public StomachLevel stomachLevel;
    public HydrationLevel hydrationLevel;

    public float waitBetweenChomp;

    public NoodleCounter noodleCount;
    public PointCounter pointCounter;

    //public Transform waterBottleTransform;

    private int chompsPending = 0;

    public void PlaySound()
    {
        string name = "chomp_effect_" + chompsPending + 1;
        AudioSource source = AudioManager.audioManager.PushSource(name, chompSoundEffect);
        chompsPending++;
        source.Play();
        StartCoroutine(WaitForPlay(source.clip.length, name));
    }

    private IEnumerator WaitForPlay(float clipLength, string name)
    {
        yield return new WaitForSeconds(clipLength);
        AudioManager.audioManager.RemoveSource(name);
    }

    public void Chomp()
    {
        PlaySound();
        StartCoroutine(WaitForSwitch());
    }

    public IEnumerator WaitForSwitch()
    {
        GetComponent<SpriteRenderer>().sprite = mouthClosed;
        yield return new WaitForSeconds(waitBetweenChomp);
        GetComponent<SpriteRenderer>().sprite = mouthOpen;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Collision " + collision.gameObject.name);
        if (collision.gameObject.GetComponent<NoodleBowl>() != null)
        {
            NoodleBowl noodleBowl = collision.gameObject.GetComponent<NoodleBowl>();

            stomachLevel.stomachLevel += noodleBowl.currentNoodleType.stomach;
            hydrationLevel.hydrationLevel -= noodleBowl.currentNoodleType.hydration;

            //Debug.Log(noodleBowl.currentNoodleType.pointValue);
            if(MultiPGameManager.gameManager)
            {
                MultiPGameManager.gameManager.currentPlayer.points += noodleBowl.currentNoodleType.pointValue;
            }
            else
            {
                GameManager.gameManager.currentPlayer.points += noodleBowl.currentNoodleType.pointValue;
            }
            //Debug.Log("Points: " + pointCounter.points);

            noodleCount.noodleCount++;

            noodleBowl.DestroyNoodle();
            Chomp();
        }

        if (collision.gameObject.name.ToUpper().Contains("WATER"))
        {
            Debug.Log("Drinking Water");
            hydrationLevel.hydrationLevel += collision.gameObject.GetComponent<WaterBottle>().currentItemType.hydration;
            Chomp();
            Destroy(collision.gameObject);
        }

    }

    // Update is called once per frame
    void Update () {


		
	}
}
