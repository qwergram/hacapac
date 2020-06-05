using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class editor_globals : MonoBehaviour
{
    private string selected_tool = "none";
    private Sprite selected_sprite = null;
    private GameObject selected;

    public TileBase wall;
    public TileBase pacman;
    public TileBase pellet;
    public TileBase powerPellet;
    public TileBase pinkGhost;
    public TileBase redGhost;
    public TileBase blueGhost;
    public TileBase emptySpace;

    private TileBase selectedTile = null;

    public Tilemap tilemap;

    // Tilemap tilemap;

    public string getSelectedTool() {
        return selected_tool;
    }

    public void set_selected_tool(string new_tool, Sprite new_sprite) {
        selected_tool = new_tool;
        selected_sprite = new_sprite;
        SpriteRenderer sr = selected.GetComponent<SpriteRenderer>();
        sr.sprite = selected_sprite;
        switch (selected_tool)
        {
        case "emptySpace":
            selectedTile = emptySpace;
            break;
        case "wall":
            selectedTile = wall;
            break;
        case "pacman":
            selectedTile = pacman;
            break;
        case "pellet":
            selectedTile = pellet;
            break;
        case "powerPellet":
            selectedTile = powerPellet;
            break;
        case "redGhost":
            selectedTile = redGhost;
            break;
        case "blueGhost":
            selectedTile = blueGhost;
            break;
        case "pinkGhost":
            selectedTile = pinkGhost;
            break;
        default:
            selectedTile = emptySpace;
            break;
        }
        // Debug.Log(new_tool);
        // Debug.Log(new_sprite);
    }

    void Start() {
        selectedTile = emptySpace;
        selected = new GameObject("toolCursor");
        Vector2 cursorPos = getCursorPos();
        SpriteRenderer sr = selected.AddComponent<SpriteRenderer>();
        Instantiate(selected, cursorPos, sr.transform.rotation);
    }

    void Update() {
        Vector2 cursorPos = getCursorPos();
        selected.transform.position = new Vector2(cursorPos.x, cursorPos.y);
        if (Input.GetMouseButtonDown(0)) {

            Vector3Int cellPos = tilemap.WorldToCell(getCursorPos());
            if (cellPos.x >= -9 & cellPos.x <= 19 & cellPos.y >= -5 & cellPos.y <= 27){
                tilemap.SetTile(cellPos, selectedTile);
            }
        }
    }

    private Vector2 getCursorPos() {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
