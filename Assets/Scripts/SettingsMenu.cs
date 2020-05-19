using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{

    public void Start() {
        pacmanMoveSpeedSlider.value = pacmanMoveSpeed;
        ghostMoveSpeedSlider.value = ghostMoveSpeed;
        ghostFrightenedTimeSlider.value = ghostTimeFrightened;
        masterVolumeSlider.value = volume;
        soundFXVolumeSlider.value = soundFXVolume;
        musicVolumeSlider.value = musicVolume;
    }

    public Slider pacmanMoveSpeedSlider;
    public Slider ghostMoveSpeedSlider;
    public Slider ghostFrightenedTimeSlider;
    public Slider masterVolumeSlider;
    public Slider soundFXVolumeSlider;
    public Slider musicVolumeSlider;

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
    public float volume
    {
        get { return Settings.masterVolume; }
        set { Settings.masterVolume = value; }
    }

    public float soundFXVolume {
        get { return Settings.soundFXVolume; }
        set { Settings.soundFXVolume = value; }
    }

    public float musicVolume {
        get { return Settings.musicVolume; }
        set { Settings.musicVolume = value; }
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
