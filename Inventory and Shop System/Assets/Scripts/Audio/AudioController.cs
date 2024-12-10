using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private Dictionary<AudioType, AudioClip> _audioClipDictionary;
    private AudioSource _audioSource;

    public void Init(List<AudioScriptableObject> audioSO, AudioSource audioSource)
    {
        _audioClipDictionary = new Dictionary<AudioType, AudioClip>();
        _audioSource = audioSource;

        foreach (var audioData in audioSO)
        {
            if (!_audioClipDictionary.ContainsKey(audioData.audioType))
            {
                _audioClipDictionary[audioData.audioType] = audioData.audioClip;
            }
        }
    }

    public void PlaySound(AudioType audioType)
    {
        if(_audioClipDictionary.TryGetValue(audioType, out AudioClip clip))
        {
            _audioSource.clip = clip;
            _audioSource.PlayOneShot(_audioSource.clip);
        }
    }
}
