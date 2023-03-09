using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager _audioManager { get; private set; }

    [SerializeField] private Sound[] musicSounds, sfxSounds, voiceSounds;
    [SerializeField] private AudioSource musicSource, sfxSource, voiceSource;

    private void Awake()
    {
        if (_audioManager == null)
            _audioManager = this;
        else Destroy(this);
    }

    public void PlayMusic(string name)
    {
        Sound sound = Array.Find(musicSounds, sound => sound.name == name);

        if (sound == null)
        {
            Debug.LogWarning("Music: " + name + " not found!");
            return;
        }

        musicSource.clip = sound.clip;
        musicSource.volume = sound.volume;
        musicSource.pitch = sound.pitch;
        musicSource.loop = sound.loop;
        musicSource.Play();
    }

    public void PlaySFX(string name)
    {
        Sound sound = Array.Find(sfxSounds, sound => sound.name == name);

        if (sound == null)
        {
            Debug.LogWarning("Sound Effect: " + name + " not found!");
            return;
        }

        sfxSource.clip = sound.clip;
        sfxSource.volume = sound.volume;
        sfxSource.pitch = sound.pitch;
        sfxSource.PlayOneShot(sound.clip);
    }

    public void PlayVoice(string name)
    {
        Sound sound = Array.Find(voiceSounds, sound => sound.name == name);

        if (sound == null)
        {
            Debug.LogWarning("Voice: " + name + " not found!");
            return;
        }

        voiceSource.clip = sound.clip;
        voiceSource.volume = sound.volume;
        voiceSource.pitch = sound.pitch;
        voiceSource.PlayOneShot(sound.clip);
    }

    public void StopMusic(string name)
    {
        Sound sound = Array.Find(musicSounds, sound => sound.name == name);

        if (sound == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        musicSource.Stop();
    }
}
