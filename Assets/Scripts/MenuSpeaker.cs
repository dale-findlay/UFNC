using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSpeaker : MonoBehaviour {

    public Sprite mute;
    public Sprite muteHover;
    public Sprite mutePressed;

    public Sprite speaker;
    public Sprite speakerHover;
    public Sprite speakerPressed;

    public bool muted = false;

    private void Start()
    {
        muted = AudioManager.audioManager.muted;
    }

    public void OnClick()
    {
        if(muted)
        {
            //Muted
            Button button = GetComponent<Button>();
            Image image = GetComponent<Image>();

            image.sprite = mute;

            SpriteState ss = new SpriteState();
            ss.highlightedSprite = muteHover;
            ss.pressedSprite = mutePressed;
            button.spriteState = ss;

            AudioManager.audioManager.UnmuteSound();            

            muted = false;
        }
        else
        {
            //now unmuted
            Button button = GetComponent<Button>();
            Image image = GetComponent<Image>();

            image.sprite = speaker;

            SpriteState ss = new SpriteState();
            ss.highlightedSprite = speakerHover;
            ss.pressedSprite = speakerPressed;


            button.spriteState = ss;

            AudioManager.audioManager.MuteSound();

            muted = true;
        }
    }

}
