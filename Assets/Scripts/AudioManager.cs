using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager audioManager;
    private Dictionary<string, AudioSource> audioSourceNames = new Dictionary<string, AudioSource>();

    List<AudioSource> fadeOutSources = new List<AudioSource>();

    public float audioFadeTime = 2.0f;
    public bool muted = false;

    private void Awake()
    {
        if (audioManager)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            audioManager = this;
            DontDestroyOnLoad(this);
        }
    }

    public void MuteSound()
    {
        muted = true;

        foreach (KeyValuePair<string, AudioSource> source in audioSourceNames)
        {
            source.Value.mute = true;
        }
    }

    public void UnmuteSound()
    {
        muted = false;

        foreach (KeyValuePair<string, AudioSource> source in audioSourceNames)
        {
            source.Value.mute = false;
        }
    }

    public AudioSource GetSource(string name)
    {
        if (audioSourceNames.ContainsKey(name))
        {
            return audioSourceNames[name];
        }
        else
        {
            //Debug.Log("Audio Source " + name + " Doesnt Exist");
            return null;
        }
    }

    public AudioSource PushSource(string name, AudioClip clip, bool loop = false, float volume = 0.15f)
    {
        AudioSource source = gameObject.AddComponent<AudioSource>();
        source.clip = clip;
        source.loop = loop;
        source.volume = volume;

        if (muted)
        {
            source.mute = true;
        }

        audioSourceNames.Add(name, source);

        return source;
    }

    public bool RemoveSource(string name)
    {
        bool b = audioSourceNames.Remove(name);
        Destroy(GetSource(name));

        return b;
    }

    public void RemoveFadeOut(string name)
    {
        AudioSource source = GetSource(name);

        fadeOutSources.Add(source);

        audioSourceNames.Remove(name);
    }

    private void RemoveSource(AudioSource source)
    {
        Destroy(source);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        List<AudioSource> removedSources = new List<AudioSource>();

        foreach (AudioSource source in fadeOutSources)
        {
            if (source != null)
            {

                //Debug.Log(source.clip.name + " " + source.volume);
                source.volume = Mathf.Lerp(source.volume, 0, Time.deltaTime * audioFadeTime);

                if (source.volume <= 0.05)
                {
                    removedSources.Add(source);
                    RemoveSource(source);
                }
            }
        }

        foreach (AudioSource source in removedSources)
        {
            fadeOutSources.Remove(source);
        }

    }
}
