using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sounds
{
    public AudioClip clip;

    public string name;
    
    public AudioMixerGroup audioMixer;
    
    public bool loop;
    public bool playOnAwake;

    [Range(0f, 1f)]
    public float volume;

    [Range(0.1f, 3f)]
    public float pitch;



    [HideInInspector]
    public AudioSource source;
}
