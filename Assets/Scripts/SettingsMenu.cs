using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    private float _volume;
    public float Volume {
        get { return _volume; }
        private set { _volume = value; }
    }

    public void SetVolume (float volume)
    {
        Volume = volume;
        audioMixer.SetFloat("MasterVolume", volume);
    }
}
