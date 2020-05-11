using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PacMan : MonoBehaviour
{
    // User configurable
    public float moveSpeed = 6.0f;
    public float timeInvincible = 10.0f;
    public new AudioSource audio;

    // Instance of game
    private GameSetup game;

    // Starting position
    private Vector2 startingPosition = new Vector2(14, 7);

    // Movement related
    private InputManager inputManager;
    public Transform movePoint;
    public LayerMask whatStopsMovement;
    public bool canMove = true;
    private Vector2 newDirection = Vector2.zero;    // Newly input direction
    private Vector2 oldDirection = Vector2.zero;    // Previous/current direction

    // Attribute related
    private int pelletsConsumed = 0;
    public int score = 0;

    // Frightened mode related
    private bool isInvincible = false;
    private float invincibleTimer;

    // Animation related
    private Animator anim;

    // Audio related
    public AudioClip chomp1;
    public AudioClip chomp2;
    private bool chomp1Played = false;

    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.FindGameObjectWithTag("Game").GetComponent<GameSetup>();
        inputManager = InputManager.instance;
        movePoint.parent = null;
        anim = GetComponent<Animator>();
        audio = transform.GetComponent<AudioSource>();
    }

    public void Restart()
    {
        // Restart PacMan
        anim.SetBool("Dead", false);
        transform.position = startingPosition;
        movePoint.position = startingPosition;
        newDirection = Vector2.zero;
        oldDirection = Vector2.zero;
        transform.GetComponent<SpriteRenderer>().enabled = true;
        canMove = true;

        // Restart Ghosts
        GameObject[] blinkys = GameObject.FindGameObjectsWithTag("Blinky");
        foreach (GameObject blinky in blinkys)
        {
            blinky.GetComponent<SpriteRenderer>().enabled = true;
        }
        GameObject[] inkys = GameObject.FindGameObjectsWithTag("Inky");
        foreach (GameObject inky in inkys)
        {
            inky.GetComponent<SpriteRenderer>().enabled = true;
            inky.GetComponent<Inky>().canMove = true;
        }
        GameObject[] pinkys = GameObject.FindGameObjectsWithTag("Pinky");
        foreach (GameObject pinky in pinkys)
        {
            pinky.GetComponent<SpriteRenderer>().enabled = true;
            pinky.GetComponent<Pinky>().canMove = true;
        }

        game.ChangeBGMusic("Normal");
    }

    // Update is called every frame
    void Update()
    {
        UpdateTimers();
        CheckInput();
        Move();
    }

    void UpdateTimers()
    {
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;
                game.ChangeBGMusic("Normal");
            }
        }
    }

    // Movement related
    private void CheckInput()
    {
        // Change the direction based on input
        if (inputManager.GetKeyDown(BindableActions.Left))
        {
            newDirection = Vector2.left;
        } else if (inputManager.GetKeyDown(BindableActions.Right))
        {
            newDirection = Vector2.right;
        } else if (inputManager.GetKeyDown(BindableActions.Up))
        {
            newDirection = Vector2.up;
        } else if (inputManager.GetKeyDown(BindableActions.Down))
        {
            newDirection = Vector2.down;
        }
    }
    private void Move()
    {
        if (canMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, movePoint.position) <= 0.05f)
            {
                // If no collision between movePoint and grid, move the movePoint to the new location
                if (!Physics2D.OverlapCircle(movePoint.position + (Vector3)newDirection, 0.2f, whatStopsMovement))
                {
                    UpdateOrientation();
                    oldDirection = newDirection;
                    movePoint.position += (Vector3)newDirection;
                }
                // Else if no collision if keep going the old way, then keep going the old way
                else if (!Physics2D.OverlapCircle(movePoint.position + (Vector3)oldDirection, 0.2f, whatStopsMovement))
                {
                    movePoint.position += (Vector3)oldDirection;
                }
            }
        }
    }
    private void UpdateOrientation()
    {
        if (newDirection == Vector2.left)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (newDirection == Vector2.right)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (newDirection == Vector2.up)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.localRotation = Quaternion.Euler(0, 0, 90);
        }
        else if (newDirection == Vector2.down)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.localRotation = Quaternion.Euler(0, 0, 270);
        }
    }

    // Attribute related
    public void ConsumePellet(bool superPellet)
    {
        pelletsConsumed++;
        score += 100;
        if (superPellet)
        {
            StartInvincibleMode();
        }
        PlayChompSound();
    }
    private void StartInvincibleMode()
    {
        isInvincible = true;
        invincibleTimer = timeInvincible;
        GameObject[] blinkys = GameObject.FindGameObjectsWithTag("Blinky");
        foreach (GameObject blinky in blinkys)
        {
            blinky.GetComponent<Blinky>().StartFrightenedMode();
        }
        GameObject[] inkys = GameObject.FindGameObjectsWithTag("Inky");
        foreach (GameObject inky in inkys)
        {
            inky.GetComponent<Inky>().StartFrightenedMode();
        }
        GameObject[] pinkys = GameObject.FindGameObjectsWithTag("Pinky");
        foreach (GameObject pinky in pinkys)
        {
            pinky.GetComponent<Pinky>().StartFrightenedMode();
        }
        game.ChangeBGMusic("Frightened");
    }

    // Death and restart related
    public void StartDeath()
    {
        GameObject[] inkys = GameObject.FindGameObjectsWithTag("Inky");
        foreach (GameObject inky in inkys)
        {
            inky.GetComponent<Inky>().canMove = false;
        }
        GameObject[] pinkys = GameObject.FindGameObjectsWithTag("Pinky");
        foreach (GameObject pinky in pinkys)
        {
            pinky.GetComponent<Pinky>().canMove = false;
        }
        canMove = false;
        anim.enabled = false;
        game.backgroundMusic.Stop();

        // Like starting a separate thread
        StartCoroutine(ProcessDeathAfter(2));
    }

    private IEnumerator ProcessDeathAfter(float delay)
    {
        yield return new WaitForSeconds(delay);

        GameObject[] blinkys = GameObject.FindGameObjectsWithTag("Blinky");
        foreach (GameObject blinky in blinkys)
        {
            blinky.GetComponent<SpriteRenderer>().enabled = false;
        }
        GameObject[] inkys = GameObject.FindGameObjectsWithTag("Inky");
        foreach (GameObject inky in inkys)
        {
            inky.GetComponent<SpriteRenderer>().enabled = false;
        }
        GameObject[] pinkys = GameObject.FindGameObjectsWithTag("Pinky");
        foreach (GameObject pinky in pinkys)
        {
            pinky.GetComponent<SpriteRenderer>().enabled = false;
        }

        // Audio is 1.9s
        StartCoroutine(ProcessDeathAnimation(1.9f));
    }

    private IEnumerator ProcessDeathAnimation(float delay)
    {
        transform.localScale = new Vector3(1, 1, 1);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        anim.SetBool("Dead", true);
        anim.enabled = true;
        game.ChangeBGMusic("PacManDeath");

        yield return new WaitForSeconds(delay);

        StartCoroutine(ProcessRestart(2));
    }

    private IEnumerator ProcessRestart(float delay)
    {
        transform.GetComponent<SpriteRenderer>().enabled = false;
        game.backgroundMusic.Stop();

        yield return new WaitForSeconds(delay);

        Restart();
    }

    // Audio related
    private void PlayChompSound()
    {
        if (chomp1Played)
        {
            audio.PlayOneShot(chomp2);
            chomp1Played = false;
        }
        else
        {
            audio.PlayOneShot(chomp1);
            chomp1Played = true;
        }
    }
}
