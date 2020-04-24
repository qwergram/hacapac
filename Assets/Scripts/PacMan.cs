using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacMan : MonoBehaviour
{
    private float speed = 4.0f;

    Rigidbody2D rigidbody2d;
    private Vector2 direction = Vector2.zero;
    // The position where the PacMan was when the user inputted a command
    private Vector2 positionOfInput = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called every frame
    void Update()
    {
        CheckInput();
        Move();
    }

    void CheckInput()
    {
        // Change the direction based on input
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = Vector2.left;
            positionOfInput = rigidbody2d.position;
        } else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = Vector2.right;
            positionOfInput = rigidbody2d.position;
        } else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = Vector2.up;
            positionOfInput = rigidbody2d.position;
        } else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = Vector2.down;
            positionOfInput = rigidbody2d.position;
        }
    }

    void Move()
    {
        if (direction == Vector2.left || direction == Vector2.right)
        {
            float floor_y = Mathf.Floor(positionOfInput.y);
            float ceil_y = Mathf.Ceil(positionOfInput.y);
            float curr_y = rigidbody2d.position.y;
            if (curr_y - floor_y < 0.015f || ceil_y - curr_y < 0.015f)
            {
                rigidbody2d.velocity = direction * speed;
                UpdateOrientation();
            }
        }
        else if (direction == Vector2.up || direction == Vector2.down)
        {
            float floor_x = Mathf.Floor(positionOfInput.x);
            float ceil_x = Mathf.Ceil(positionOfInput.x);
            float curr_x = rigidbody2d.position.x;
            if (curr_x - floor_x < 0.015f || ceil_x - curr_x < 0.015f)
            {
                rigidbody2d.velocity = direction * speed;
                UpdateOrientation();
            }
        }
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
