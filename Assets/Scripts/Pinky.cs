using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinky : MonoBehaviour
{
    // User configurable
    public float moveSpeed = 2.0f;
    public float timeFrightened = 10.0f;

    // Movement related
    public Transform movePoint;
    public LayerMask whatStopsMovement;
    public bool canMove = true;
    private Vector2 direction = Vector2.right;

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
        movePoint.parent = null;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimers();
        Move();
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

    private void Move()
    {
        if (canMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, movePoint.position) <= 0.05f)
            {
                // If no collision between movePoint and grid, move the movePoint to the new location
                if (!Physics2D.OverlapCircle(movePoint.position + (Vector3)direction, 0.2f, whatStopsMovement))
                {
                    movePoint.position += (Vector3)direction;
                }
                // Else if no collision if turn around, then turn around
                else if (!Physics2D.OverlapCircle(movePoint.position + (Vector3)direction * -1, 0.2f, whatStopsMovement))
                {
                    direction *= -1;
                    movePoint.position += (Vector3)direction;
                }
                anim.SetBool("Left", direction.Equals(Vector2.left));
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
