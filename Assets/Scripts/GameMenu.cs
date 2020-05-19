﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public void Back()
    {
        Destroy(GameObject.FindGameObjectWithTag("Game"));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}