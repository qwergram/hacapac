using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacMan : MonoBehaviour
{
    private float speed = 3.0f;

    Rigidbody2D rigidbody2d;
    private Vector2 direction = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called every frame
    void Update()
    {
        CheckInput();
        UpdateOrientation();
        Move();
    }

    void CheckInput()
    {
        // Change the direction based on input
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = Vector2.left;
        } else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = Vector2.right;
        } else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = Vector2.up;
        } else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = Vector2.down;
        }
    }

    void Move()
    {
        rigidbody2d.velocity = direction * speed;
    }

    void UpdateOrientation()
    {
        if (direction == Vector2.left)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        } else if (direction == Vector2.right)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        } else if (direction == Vector2.up)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.localRotation = Quaternion.Euler(0, 0, 90);
        } else if (direction == Vector2.down)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.localRotation = Quaternion.Euler(0, 0, 270);
        }
    }
}
