using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinky : MonoBehaviour
{
    // User configurable
    public float timeFrightened = 10.0f;

    // Frightened mode related
    private bool isFrightened = false;
    private float frightenedTimer = 0f;
    private bool frightenedBlue = true;
    private float blinkTimer = 0f;

    // Animation related
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimers();
    }

    void UpdateTimers()
    {
        if (isFrightened)
        {
            frightenedTimer -= Time.deltaTime;
            // Frightened timer is up, so exit frightened mode
            if (frightenedTimer < 0)
            {
                isFrightened = false;
                anim.SetBool("Frightened_White", false);
                anim.SetBool("Frightened_Blue", false);
            }
            else if (frightenedTimer < 3)
            {
                blinkTimer += Time.deltaTime;
                if (blinkTimer >= 0.1f)
                {
                    if (frightenedBlue)
                    {
                        anim.SetBool("Frightened_White", true);
                        anim.SetBool("Frightened_Blue", false);
                        frightenedBlue = false;
                    }
                    else
                    {
                        anim.SetBool("Frightened_Blue", true);
                        anim.SetBool("Frightened_White", false);
                        frightenedBlue = true;
                    }
                    blinkTimer = 0f;
                }
            }
            else
            {
                anim.SetBool("Frightened_Blue", true);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PacMan pacman = other.GetComponent<PacMan>();

        if (pacman != null)
        {
            if (isFrightened)
            {
                // TODO:
                pacman.score += 300;
                Destroy(gameObject);
            }
            else
            {
                pacman.StartDeath();
            }
        }
    }
    public void StartFrightenedMode()
    {
        frightenedTimer = timeFrightened;
        isFrightened = true;
        frightenedBlue = true;
    }
}
