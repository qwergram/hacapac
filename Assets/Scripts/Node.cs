using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    // Neighbors we can go to
    public Node[] neighbors;
    // Directions of neighbors
    public Vector2[] validDirections;

    // Start is called before the first frame update
    void Start()
    {
        validDirections = new Vector2[neighbors.Length];
        // For each neighbor, find the valid direction to that neighbor
        for (int i = 0; i < neighbors.Length; i++)
        {
            Node neighbor = neighbors[i];
            Vector2 tempVector = neighbor.transform.localPosition - transform.localPosition;
            validDirections[i] = tempVector.normalized;
        }
    }
}
