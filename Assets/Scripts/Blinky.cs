using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinky : MonoBehaviour
{
    // Animation related
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PacMan pacman = other.GetComponent<PacMan>();

        if (pacman != null)
        {
            if (pacman.isInvincible)
            {
                // TODO:
                pacman.IncreaseScore(300);
                Destroy(gameObject);
            }
            else
            {
                pacman.Hit();
            }
        }
    }

    public void StartFrightenedMode()
    {
        anim.SetBool("Frightened", true);
    }

    public void StopFrightenedMode()
    {
        anim.SetBool("Frightened", false);
    }
}
