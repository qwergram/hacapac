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
        // Debug.Log(new_tool);
        // Debug.Log(new_sprite);
    }

    void Start() {
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
            tilemap.SetTile(cellPos, wall);

            // for (int n = tilemap.cellBounds.xMin; n < tilemap.cellBounds.xMax; n++)
            // {
            //     for (int p = tilemap.cellBounds.yMin; p < tilemap.cellBounds.yMax; p++)
            //     {
            //         Vector3Int localPlace = (new Vector3Int(n, p, (int)tilemap.transform.position.y));
            //         Vector3 place = tilemap.CellToWorld(localPlace);
            //         // Debug.Log(place);
            //         // if (tilemap.HasTile(localPlace))
            //         // {
                        
            //         // }
            //     }
            // }
        }
    }

    private Vector2 getCursorPos() {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
