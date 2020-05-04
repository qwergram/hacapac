using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class editor_select_tool : MonoBehaviour
{
    public void selectThisTool() {
        GameObject canvas = GameObject.Find("Canvas");
        editor_globals other = (editor_globals) canvas.GetComponent(typeof(editor_globals));
        Debug.Log(other);
        Sprite tool_sprite = transform.GetChild(0).gameObject.GetComponent<Image>().sprite;
        other.set_selected_tool(gameObject.name, tool_sprite);
    }
}
