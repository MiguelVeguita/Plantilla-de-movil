using UnityEngine;

[CreateAssetMenu(fileName = "NewAudioClipData", menuName = "ScriptableObjects/Audio/AudioClipData")]
public class AudioClipData : ScriptableObject
{
    [Header("Clip Settings")]
    public AudioClip clip;
    [Range(0f, 1f)] public float defaultVolume = 1f;
    public bool loop = false;
}