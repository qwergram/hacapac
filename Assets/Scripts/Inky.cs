using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inky : MonoBehaviour
{
    // User configurable
    public float moveSpeed = 2.0f;
    public float timeFrightened = 10.0f;

    // Movement related
    public Transform movePoint;
    public LayerMask whatStopsMovement;
    private Vector2 direction = Vector2.up;

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
        Move();
    }

    private void Move()
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
            else if (!Physics2D.OverlapCircle(movePoint.position + (Vector3)direction*-1, 0.2f, whatStopsMovement))
            {
                direction *= -1;
                movePoint.position += (Vector3)direction;
            }
            anim.SetBool("Down", direction.Equals(Vector2.down));
        }
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
