using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Keybindings", menuName = "Key Bindings")]
public class KeyBindings : ScriptableObject
{
    [System.Serializable]
    public class BindedKey
    {
        public BindableActions action;
        public KeyCode key;
    }

    public BindedKey[] bindedKeys;
}
