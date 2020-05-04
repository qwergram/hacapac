using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class editor_globals : MonoBehaviour
{
    private string selected_tool = "none";
    private Sprite selected_sprite = null;

    public string getSelectedTool() {
        return selected_tool;
    }

    public void set_selected_tool(string new_tool, Sprite new_sprite) {
        selected_tool = new_tool;
        selected_sprite = new_sprite;
        Debug.Log(new_tool);
        Debug.Log(new_sprite);
    }
}
