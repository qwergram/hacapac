using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetup : MonoBehaviour
{
    // TODO: CHANGE LATER
    // Start is called before the first frame update
    void Start()
    {
        PacMan pacman = GameObject.FindGameObjectWithTag("PacMan").GetComponent<PacMan>();
        pacman.moveSpeed = 6.0f;
        pacman.timeInvincible = 10.0f;
        GameObject[] inkyGameObjects = GameObject.FindGameObjectsWithTag("Inky");
        foreach (GameObject inkyGameObject in inkyGameObjects)
        {
            Inky inky = inkyGameObject.GetComponent<Inky>();
            inky.moveSpeed = 2.0f;
            inky.timeFrightened = 10.0f;
        }
        GameObject[] pinkyGameObjects = GameObject.FindGameObjectsWithTag("Pinky");
        foreach (GameObject pinkyGameObject in pinkyGameObjects)
        {
            Pinky pinky = pinkyGameObject.GetComponent<Pinky>();
            pinky.moveSpeed = 2.0f;
            pinky.timeFrightened = 10.0f;
        }
    }
}
