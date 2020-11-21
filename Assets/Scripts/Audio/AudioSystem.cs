using UnityEngine;
using System.Collections.Generic;
using System;



public class AudioSystem : MonoBehaviour
{


    public GameSoundEffectClips[] SoundEffectClips;
    private List<AudioSource> currentPlayingSources;
    private AudioSource currentPlayingSource;
    private AudioSource currentPlayingMusicSource;
    public bool simultaneousPlaying;

    void Start()
    {
        currentPlayingSources = new List<AudioSource>();
    }

    public void PlaySound(string soundEffectName, GameObject playingSoundGO, bool loop = false)
    {
        AudioSource source = playingSoundGO.GetComponent<AudioSource>();
        if(source != null)
        {
            if (!simultaneousPlaying)
            {
                if (currentPlayingSource != null)
                {
                    currentPlayingSource.Stop();
                }
                currentPlayingSource = source;
            }
            else
            {
                currentPlayingSources.Add(source);
            }
        }
        else
        {
            Debug.LogError("Attempting to play a sound from an object that doesn't have an audio source component");
        }
        AudioClip clip = FindClip(soundEffectName);
        if (clip != null)
        {
            source.clip = clip;
            source.loop = loop;
            source.Play();
        }
    }

    public void StopSound(GameObject playingSoundGO)
    {
        AudioSource source = playingSoundGO.GetComponent<AudioSource>();
        if(source != null)
        {
            source.Stop();
        }
        else
        {
            Debug.LogError("Trying to stop a sound on an object without an audio source component");
        }
    }

    public bool IsSourcePlayingSound(string sound, GameObject playingSoundGO)
    {
        AudioSource source = playingSoundGO.GetComponent<AudioSource>();
        if (source != null)
        {
            if(source.isPlaying && source.clip == FindClip(sound))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            Debug.LogError("Trying to check a gameobject without a audio source component");
            return false;
        }
    }

    public void PlayMusic(string musicName, GameObject playingMusicGO)
    {
        AudioSource source = playingMusicGO.GetComponent<AudioSource>();
        if (source != null)
        {
            if (currentPlayingMusicSource != null)
            {
                currentPlayingMusicSource.Stop();
            }
            currentPlayingMusicSource = source;
        }
        else
        {
            Debug.LogError("Attempting to play music from an object that doesn't have an audio source component");
        }
        AudioClip clip = FindClip(musicName);
        if(clip != null)
        {
            source.clip = clip;
            source.Play();
        }
    }

    public AudioClip FindClip(string clipName)
    {
        for (int i = 0; i < SoundEffectClips.Length; i++)
        {
            if(SoundEffectClips[i].name == clipName)
            {
                return SoundEffectClips[i].clip;
            }
        }
        Debug.LogError("AudioSystem(FindClip(string clipName)): Was unable to find a clip under name " + clipName);
        return null;
    }

    private void StopCurrentPlayingSources()
    {
        foreach (AudioSource source in currentPlayingSources)
        {
            source.Stop();
        }
        currentPlayingSources = null;
    }

}

[Serializable]
public struct GameSoundEffectClips
{
    public string name;
    public AudioClip clip;
}

[Serializable]
public struct GameMusicClips
{
    public string name;
    public AudioClip clip;
}