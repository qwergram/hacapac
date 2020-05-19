using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{

    public void Start() {
        
    }

    public Slider masterVolumeSlider;

    // User configurable options: PacMan speed, Ghost speed, Ghost time frightened, Music volume, Sound FX volume
    public float pacmanMoveSpeed {
        get { return Settings.pacmanMoveSpeed; }
        set { Settings.pacmanMoveSpeed = value; }
    }

    public float ghostMoveSpeed {
        get { return Settings.ghostMoveSpeed; }
        set { Settings.ghostMoveSpeed = value; }
    }

    public float ghostTimeFrightened {
        get { return Settings.ghostTimeFrightened; }
        set { Settings.ghostTimeFrightened = value; }
    }
    
    public float soundFXVolume {
        get { return Settings.soundFXVolume * Settings.masterVolume; }
        set { Settings.soundFXVolume = value; }
    }

    public float musicVolume {
        get { return Settings.musicVolume * Settings.masterVolume; }
        set { Settings.musicVolume = value; }
    }

    public float volume {
        get { return Settings.masterVolume; }
        set { Settings.masterVolume = value; }
    }

    public void SetDefaultVolume ()
    {
        masterVolumeSlider.value = Settings.masterVolume;
        this.volume = Settings.masterVolume;
    }

    public void SetVolume (float volume)
    {
        this.volume = volume;
    }

    public void SetMusicVolume (float volume)
    {
        this.musicVolume = volume;
    }

    public void SetSFXVolume (float volume)
    {
        this.soundFXVolume = volume;
    }

    public void SetPacmanSpeed (float speed)
    {
        this.pacmanMoveSpeed = speed;
    }

    public void SetGhostSpeed (float speed)
    {
        this.ghostMoveSpeed = speed;
    }

    public void SetGhostFrightened (float time)
    {
        this.ghostTimeFrightened = time;
    }
}
