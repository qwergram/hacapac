using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{

    public void Start() {
        InitializeSettings();
        pacmanMoveSpeedSlider.value = pacmanMoveSpeed;
        ghostMoveSpeedSlider.value = ghostMoveSpeed;
        ghostFrightenedTimeSlider.value = ghostTimeFrightened;
        masterVolumeSlider.value = masterVolume;
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
        set { Settings.pacmanMoveSpeed = value;
            PlayerPrefs.SetFloat("pacmanMoveSpeed", value);
        }
    }

    public float ghostMoveSpeed {
        get { return Settings.ghostMoveSpeed; }
        set { Settings.ghostMoveSpeed = value;
            PlayerPrefs.SetFloat("ghostMoveSpeed", value);
        }
    }

    public float ghostTimeFrightened {
        get { return Settings.ghostTimeFrightened; }
        set { Settings.ghostTimeFrightened = value;
            PlayerPrefs.SetFloat("ghostTimeFrightened", value);
        }
    }
    public float masterVolume
    {
        get { return Settings.masterVolume; }
        set { Settings.masterVolume = value;
            PlayerPrefs.SetFloat("masterVolume", value);
        }
    }

    public float soundFXVolume {
        get { return Settings.soundFXVolume; }
        set { Settings.soundFXVolume = value;
            PlayerPrefs.SetFloat("soundFXVolume", value);
        }
    }

    public float musicVolume {
        get { return Settings.musicVolume; }
        set { Settings.musicVolume = value; 
            PlayerPrefs.SetFloat("musicVolume", value);
        }
    }

    private void InitializeSettings()
    {
        float pacmanMoveSpeedRead = PlayerPrefs.GetFloat("pacmanMoveSpeed", -1);
        if (pacmanMoveSpeedRead != -1)
        {
            Settings.pacmanMoveSpeed = pacmanMoveSpeedRead;
        }
        float ghostMoveSpeedRead = PlayerPrefs.GetFloat("ghostMoveSpeed", -1);
        if (ghostMoveSpeedRead != -1)
        {
            Settings.ghostMoveSpeed = ghostMoveSpeedRead;
        }
        float ghostTimeFrightenedRead = PlayerPrefs.GetFloat("ghostTimeFrightened", -1);
        if (ghostTimeFrightenedRead != -1)
        {
            Settings.ghostTimeFrightened = ghostTimeFrightenedRead;
        }
        float masterVolumeRead = PlayerPrefs.GetFloat("masterVolume", -1);
        if (masterVolumeRead != -1)
        {
            Settings.masterVolume = masterVolumeRead;
        }
        float soundFXVolumeRead = PlayerPrefs.GetFloat("soundFXVolume", -1);
        if (soundFXVolumeRead != -1)
        {
            Settings.soundFXVolume = soundFXVolumeRead;
        }
        float musicVolumeRead = PlayerPrefs.GetFloat("musicVolume", -1);
        if (musicVolumeRead != -1)
        {
            Settings.musicVolume = musicVolumeRead;
        }
    }

    public void SetVolume (float volume)
    {
        this.masterVolume = volume;
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
