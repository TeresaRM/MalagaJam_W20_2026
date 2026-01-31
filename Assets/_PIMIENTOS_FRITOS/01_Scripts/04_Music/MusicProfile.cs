using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class MusicProfile
{
    public string id; 
    public AudioClip musicClip;
    public List<string> allowedScenes;
    public bool restartOnSwitch = false;
    [Range(0f, 1f)] public float volume = 1f;
}
