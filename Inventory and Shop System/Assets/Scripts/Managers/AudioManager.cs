using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager
{
    private AudioController _audioController;

    public AudioManager(AudioController audioController, List<AudioScriptableObject> audioSO, AudioSource audioSource)
    {
        _audioController = audioController;
        audioController.Init(audioSO, audioSource);
    }

    public void PlaySound(AudioType audioType)
    {
        _audioController.PlaySound(audioType);
    }
}
