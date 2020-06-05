using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour
{
    public void Back()
    {
        Destroy(GameObject.FindGameObjectWithTag("Game"));
        SceneManager.LoadScene("MainMenu");
    }

    public void Edit()
    {
        Destroy(GameObject.FindGameObjectWithTag("Game"));
        SceneManager.LoadScene("Editor");
    }
}