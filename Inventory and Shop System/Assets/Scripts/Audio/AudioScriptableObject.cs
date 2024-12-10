using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioScriptableObject", menuName = "ScriptableObjects/AudioScriptableObject")]
public class AudioScriptableObject : ScriptableObject
{
    public AudioType audioType;
    public AudioClip audioClip;
}
