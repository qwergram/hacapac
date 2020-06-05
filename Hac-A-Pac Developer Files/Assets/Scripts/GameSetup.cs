using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSetup : MonoBehaviour
{
    // Prefabs
    public GameObject blockGO;
    public GameObject pacmanGO;
    public GameObject blinkyGO;
    public GameObject inkyGO;
    public GameObject pinkyGO;
    public GameObject pelletGO;
    public GameObject superpelletGO;

    public AudioClip backgroundMusic_Intro;
    public AudioClip backgroundMusic_Normal;
    public AudioClip backgroundMusic_Frightened;
    public AudioClip backgroundMusic_PacManDeath;
    public AudioSource backgroundMusic;

    // Start is called before the first frame update
    void Start()
    {
        BuildLevel();
        ConfigureMusic();
        ConfigurePacMan();
        ConfigureGhosts();
        StartIntro();
    }

    void BuildLevel()
    {
        string[] lines = File.ReadAllLines(Application.streamingAssetsPath + "/CustomLevel.txt");

        for (int y = 0; y < lines.Length; y++)
        {
            char[] line = lines[y].ToCharArray();
            for (int x = 0; x < line.Length; x++)
            {
                Vector3 position = new Vector3(x + 0.5f, lines.Length - 1 - y - 0.5f);
                switch (line[x])
                {
                    case '#':
                        position = new Vector3(x, lines.Length - 1 - y);
                        Instantiate(blockGO, position, Quaternion.identity);
                        break;
                    case '@':
                        Instantiate(pacmanGO, position, Quaternion.identity);
                        break;
                    case 'B':
                        Instantiate(blinkyGO, position, Quaternion.identity);
                        break;
                    case 'I':
                        Instantiate(inkyGO, position, Quaternion.identity);
                        break;
                    case 'P':
                        Instantiate(pinkyGO, position, Quaternion.identity);
                        break;
                    case 'o':
                        Instantiate(pelletGO, position, Quaternion.identity);
                        break;
                    case 'O':
                        Instantiate(superpelletGO, position, Quaternion.identity);
                        break;
                    default:
                        break;
                }
            }
        }
    }

    void ConfigureMusic()
    {
        backgroundMusic.volume = Settings.musicVolume * Settings.masterVolume;
    }

    void ConfigurePacMan()
    {
        GameObject pacmanGameObject = GameObject.FindGameObjectWithTag("PacMan");
        if(pacmanGameObject != null)
        {
            PacMan pacman = pacmanGameObject.GetComponent<PacMan>();
            pacman.moveSpeed = Settings.pacmanMoveSpeed;
            pacman.timeInvincible = Settings.ghostTimeFrightened;
            pacman.audio.volume = Settings.soundFXVolume;
        }
    }

    void ConfigureGhosts()
    {
        GameObject[] blinkyGameObjects = GameObject.FindGameObjectsWithTag("Blinky");
        foreach (GameObject blinkyGameObject in blinkyGameObjects)
        {
            Blinky blinky = blinkyGameObject.GetComponent<Blinky>();
            blinky.timeFrightened = Settings.ghostTimeFrightened;
        }
        GameObject[] inkyGameObjects = GameObject.FindGameObjectsWithTag("Inky");
        foreach (GameObject inkyGameObject in inkyGameObjects)
        {
            Inky inky = inkyGameObject.GetComponent<Inky>();
            inky.moveSpeed = Settings.ghostMoveSpeed;
            inky.timeFrightened = Settings.ghostTimeFrightened;
        }
        GameObject[] pinkyGameObjects = GameObject.FindGameObjectsWithTag("Pinky");
        foreach (GameObject pinkyGameObject in pinkyGameObjects)
        {
            Pinky pinky = pinkyGameObject.GetComponent<Pinky>();
            pinky.moveSpeed = Settings.ghostMoveSpeed;
            pinky.timeFrightened = Settings.ghostTimeFrightened;
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
}
