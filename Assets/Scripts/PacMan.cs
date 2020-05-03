﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacMan : MonoBehaviour
{
    // User configurable
    public float moveSpeed = 6.0f;
    public float timeInvincible = 10.0f;

    // Movement related
    public Transform movePoint;
    public LayerMask whatStopsMovement;
    private Vector2 newDirection = Vector2.zero;    // Newly input direction
    private Vector2 oldDirection = Vector2.zero;    // Previous/current direction

    // Attribute related
    private int pelletsConsumed = 0;
    private int score = 0;

    // Frightened mode related
    public bool isInvincible { get { return _isInvincible; } }
    private bool _isInvincible = false;
    private float invincibleTimer;

    // Audio related
    public AudioClip chomp1;
    public AudioClip chomp2;
    private new AudioSource audio;
    private bool chomp1Played = false;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
        audio = transform.GetComponent<AudioSource>();
    }

    // Update is called every frame
    void Update()
    {
        //UpdateTimers();
        CheckInput();
        Move();
    }

    //void UpdateTimers()
    //{
    //    if (_isInvincible)
    //    {
    //        invincibleTimer -= Time.deltaTime;
    //        if (invincibleTimer < 0)
    //        {
    //            _isInvincible = false;
    //            StopFrightenedMode();
    //        }
    //    }
    //}

    // Movement related
    private void CheckInput()
    {
        // Change the direction based on input
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            newDirection = Vector2.left;
        } else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            newDirection = Vector2.right;
        } else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            newDirection = Vector2.up;
        } else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            newDirection = Vector2.down;
        }
    }
    private void Move()
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
    public void ConsumePellet(string pellet)
    {
        pelletsConsumed++;
        score += 100;
        if (pellet.Equals("SuperPellet"))
        {
            _isInvincible = true;
            invincibleTimer = timeInvincible;
            StartFrightenedMode();
        }
        PlayChompSound();
    }
    private void StartFrightenedMode()
    {
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
    }
    //private void StopFrightenedMode()
    //{
    //    GameObject[] blinkys = GameObject.FindGameObjectsWithTag("Blinky");
    //    foreach (GameObject blinky in blinkys)
    //    {
    //        blinky.GetComponent<Blinky>().StopFrightenedMode();
    //    }
    //    GameObject[] inkys = GameObject.FindGameObjectsWithTag("Inky");
    //    foreach (GameObject inky in inkys)
    //    {
    //        inky.GetComponent<Inky>().StopFrightenedMode();
    //    }
    //    GameObject[] pinkys = GameObject.FindGameObjectsWithTag("Pinky");
    //    foreach (GameObject pinky in pinkys)
    //    {
    //        pinky.GetComponent<Pinky>().StopFrightenedMode();
    //    }
    //}
    public void Hit()
    {
        // TODO:
        Destroy(gameObject);
    }
    public void IncreaseScore(int scoreIncrease)
    {
        score += scoreIncrease;
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
