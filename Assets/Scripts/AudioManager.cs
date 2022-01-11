using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public SoundSettings[] sounds;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        foreach (SoundSettings settings in sounds)
        {
            settings.audioSource = gameObject.AddComponent<AudioSource>();
            settings.audioSource.clip = settings.clip;
            settings.audioSource.pitch = settings.pitch;
            settings.audioSource.loop = settings.loop;
        }
    }
    public void Play(string sound)
    {
        SoundSettings settings = Array.Find(sounds, item => item.name == sound);
        settings.audioSource.Play();
    }
    public void Stop(string sound)
    {
        SoundSettings settings = Array.Find(sounds, item => item.name == sound);
        settings.audioSource.Stop();
    }
}
