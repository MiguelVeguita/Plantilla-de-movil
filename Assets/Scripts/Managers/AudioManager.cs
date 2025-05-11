

// Assets/Scripts/Managers/AudioManager.cs
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : PersistentSingleton<AudioManager>
{
    [Header("Audio Mixers")]
    public AudioMixer mainMixer;

    public event Action<float> OnMasterVolumeChanged;
    public event Action<float> OnMusicVolumeChanged;
    public event Action<float> OnSFXVolumeChanged;

    public void SetMasterVolume(float volume)
    {
        mainMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
        OnMasterVolumeChanged?.Invoke(volume);
    }

    public void SetMusicVolume(float volume)
    {
        mainMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
        OnMusicVolumeChanged?.Invoke(volume);
    }

    public void SetSFXVolume(float volume)
    {
        mainMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
        OnSFXVolumeChanged?.Invoke(volume);
    }

    public float GetVolume(string parameter)
    {
        float value;
        mainMixer.GetFloat(parameter, out value);
        return Mathf.Pow(10, value / 20);
    }
}