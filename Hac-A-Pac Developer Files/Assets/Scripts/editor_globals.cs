using System.IO;
using System.Collections;
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
    }

    void Start() {
        selectedTile = emptySpace;
        selected = new GameObject("toolCursor");
        SpriteRenderer sr = selected.AddComponent<SpriteRenderer>();
        Instantiate(selected, getCursorPos(), sr.transform.rotation);
        BuildLevel();
    }

    void Update() {
        Vector2 cursorPos = getCursorPos();
        selected.transform.position = new Vector2(cursorPos.x, cursorPos.y);
        // Only allow click and drag for walls, empty space, pellets and power pellets
        if(selectedTile == wall || selectedTile == emptySpace || selectedTile == pellet || selectedTile == powerPellet)
        {
            if (Input.GetMouseButton(0))
            {
                Vector3Int cellPos = tilemap.WorldToCell(getCursorPos());
                if (cellPos.x >= -9 & cellPos.x <= 19 & cellPos.y >= -5 & cellPos.y <= 27)
                {
                    tilemap.SetTile(cellPos, selectedTile);
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3Int cellPos = tilemap.WorldToCell(getCursorPos());
                if (cellPos.x >= -9 & cellPos.x <= 19 & cellPos.y >= -5 & cellPos.y <= 27)
                {
                    tilemap.SetTile(cellPos, selectedTile);
                }
            }
        }
    }

    private Vector2 getCursorPos() {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void BuildLevel()
    {
        string[] lines = File.ReadAllLines(Application.streamingAssetsPath + "/CustomLevel.txt");

        for (int y = 0; y < lines.Length; y++)
        {
            char[] line = lines[y].ToCharArray();
            for (int x = 0; x < line.Length; x++)
            {
                // TODO: Fix position for other tiles
                Vector3Int position = new Vector3Int(x + tilemap.cellBounds.xMin, tilemap.cellBounds.yMax - 1 - y, 0);
                switch (line[x])
                {
                    case '#':
                        tilemap.SetTile(position, wall);
                        break;
                    case '@':
                        tilemap.SetTile(position, pacman);
                        break;
                    case 'B':
                        tilemap.SetTile(position, redGhost);
                        break;
                    case 'I':
                        tilemap.SetTile(position, blueGhost);
                        break;
                    case 'P':
                        tilemap.SetTile(position, pinkGhost);
                        break;
                    case 'o':
                        tilemap.SetTile(position, pellet);
                        break;
                    case 'O':
                        tilemap.SetTile(position, powerPellet);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
