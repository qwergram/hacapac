using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinky : MonoBehaviour
{
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
}
