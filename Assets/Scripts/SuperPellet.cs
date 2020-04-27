using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperPellet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        PacMan pacman = other.GetComponent<PacMan>();

        if (pacman != null)
        {
            pacman.TriggerInvincibility();
            Destroy(gameObject);
        }
    }
}
