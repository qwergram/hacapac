using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BindableActions
{
    Left,
    Right,
    Up,
    Down,
}

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    [SerializeField]
    private KeyBindings keyBindings;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }

    public KeyCode GetKeyForAction(BindableActions action)
    {
        foreach(KeyBindings.BindedKey bindedKey in keyBindings.bindedKeys)
        {
            if (bindedKey.action == action)
            {
                return bindedKey.key;
            }
        }

        return KeyCode.None;
    }

    public bool GetKeyDown(BindableActions action)
    {
        foreach(KeyBindings.BindedKey bindedKey in keyBindings.bindedKeys)
        {
            if (bindedKey.action == action)
            {
                return Input.GetKeyDown(bindedKey.key);
            }
        }
        return false;
    }

     public bool GetKeyUp(BindableActions action)
    {
        foreach(KeyBindings.BindedKey bindedKey in keyBindings.bindedKeys)
        {
            if (bindedKey.action == action)
            {
                return Input.GetKeyUp(bindedKey.key);
            }
        }
        return false;
    }
}
