using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetup : MonoBehaviour
{
    public AudioClip backgroundMusic_Normal;
    public AudioClip backgroundMusic_Frightened;
    public AudioClip backgroundMusic_PacManDeath;
    public AudioSource backgroundMusic;

    // Start is called before the first frame update
    void Start()
    {
        ConfigureMusic();
        ConfigurePacMan();
        ConfigureGhosts();
    }
    void ConfigureMusic()
    {
        backgroundMusic.volume = 1.0f;
    }

    void ConfigurePacMan()
    {
        PacMan pacman = GameObject.FindGameObjectWithTag("PacMan").GetComponent<PacMan>();
        pacman.moveSpeed = 6.0f;
        pacman.timeInvincible = 10.0f;
        pacman.audio.volume = 1.0f;
    }

    void ConfigureGhosts()
    {
        GameObject[] inkyGameObjects = GameObject.FindGameObjectsWithTag("Inky");
        foreach (GameObject inkyGameObject in inkyGameObjects)
        {
            Inky inky = inkyGameObject.GetComponent<Inky>();
            inky.moveSpeed = 2.0f;
            inky.timeFrightened = 10.0f;
        }
        GameObject[] pinkyGameObjects = GameObject.FindGameObjectsWithTag("Pinky");
        foreach (GameObject pinkyGameObject in pinkyGameObjects)
        {
            Pinky pinky = pinkyGameObject.GetComponent<Pinky>();
            pinky.moveSpeed = 2.0f;
            pinky.timeFrightened = 10.0f;
        }
    }

    public void ChangeBGMusic(string music)
    {
        if (music.Equals("Frightened"))
        {
            backgroundMusic.clip = backgroundMusic_Frightened;
        }
        else if (music.Equals("PacManDeath"))
        {
            backgroundMusic.clip = backgroundMusic_PacManDeath;
        }
        else
        {
            backgroundMusic.clip = backgroundMusic_Normal;
        }
        backgroundMusic.Play();
    }
}
