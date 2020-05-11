using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    // User configurable options: PacMan speed, Ghost speed, Ghost time frightened, Music volume, Sound FX volume
    public float pacmanMoveSpeed = 6.0f;
    public float ghostMoveSpeed = 2.0f;
    public float ghostTimeFrightened = 10.0f;
    public float musicVolume = 1.0f;
    public float soundFXVolume = 1.0f;

    public AudioMixer audioMixer;

    private float _volume;
    public float volume {
        get { return _volume; }
        private set { _volume = value; }
    }

    public void SetVolume (float volume)
    {
        this.volume = volume;
        audioMixer.SetFloat("MasterVolume", volume);
    }
}
