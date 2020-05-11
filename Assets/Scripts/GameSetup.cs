using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetup : MonoBehaviour
{
    public AudioClip backgroundMusic_Intro;
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
        StartIntro();
    }

    void StartIntro()
    {
        // Hide all Game Objects and play intro
        PacMan pacman = GameObject.FindGameObjectWithTag("PacMan").GetComponent<PacMan>();
        pacman.transform.GetComponent<SpriteRenderer>().enabled = false;
        pacman.canMove = false;

        GameObject[] blinkys = GameObject.FindGameObjectsWithTag("Blinky");
        foreach (GameObject blinky in blinkys)
        {
            blinky.GetComponent<SpriteRenderer>().enabled = false;
        }
        GameObject[] inkys = GameObject.FindGameObjectsWithTag("Inky");
        foreach (GameObject inky in inkys)
        {
            inky.GetComponent<SpriteRenderer>().enabled = false;
            inky.GetComponent<Inky>().canMove = false;
        }
        GameObject[] pinkys = GameObject.FindGameObjectsWithTag("Pinky");
        foreach (GameObject pinky in pinkys)
        {
            pinky.GetComponent<SpriteRenderer>().enabled = false;
            pinky.GetComponent<Pinky>().canMove = false;
        }

        StartCoroutine(ShowObjectsAfter(2.25f));
    }

    IEnumerator ShowObjectsAfter(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Show all Game Objects
        PacMan pacman = GameObject.FindGameObjectWithTag("PacMan").GetComponent<PacMan>();
        pacman.transform.GetComponent<SpriteRenderer>().enabled = true;

        GameObject[] blinkys = GameObject.FindGameObjectsWithTag("Blinky");
        foreach (GameObject blinky in blinkys)
        {
            blinky.GetComponent<SpriteRenderer>().enabled = true;
        }
        GameObject[] inkys = GameObject.FindGameObjectsWithTag("Inky");
        foreach (GameObject inky in inkys)
        {
            inky.GetComponent<SpriteRenderer>().enabled = true;
        }
        GameObject[] pinkys = GameObject.FindGameObjectsWithTag("Pinky");
        foreach (GameObject pinky in pinkys)
        {
            pinky.GetComponent<SpriteRenderer>().enabled = true;
        }

        StartCoroutine(StartGameAfter(2));
    }

    IEnumerator StartGameAfter(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Allow all Game Objects to move
        PacMan pacman = GameObject.FindGameObjectWithTag("PacMan").GetComponent<PacMan>();
        pacman.canMove = true;

        GameObject[] inkys = GameObject.FindGameObjectsWithTag("Inky");
        foreach (GameObject inky in inkys)
        {
            inky.GetComponent<Inky>().canMove = true;
        }
        GameObject[] pinkys = GameObject.FindGameObjectsWithTag("Pinky");
        foreach (GameObject pinky in pinkys)
        {
            pinky.GetComponent<Pinky>().canMove = true;
        }

        ChangeBGMusic("Normal");
        backgroundMusic.loop = true;
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
