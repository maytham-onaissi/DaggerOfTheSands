using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }

    public Sounds[] sounds;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            DontDestroyOnLoad(gameObject);
            return;
        }
        
        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.outputAudioMixerGroup = s.audioMixer;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }

        PlaySound("Theme");
    }

    
    public void PlaySound(string _sound)
    {
        Sounds s = Array.Find(sounds, sounds => sounds.name == _sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + _sound + " not found!");
            return;
        }
        s.source.Play();
    }
}
