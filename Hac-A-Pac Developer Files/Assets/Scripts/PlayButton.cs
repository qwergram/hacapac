using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class PlayButton : MonoBehaviour
{
    public Tilemap tilemap;

    public void SaveLevelAndPlay()
    {
        // save level
        List<string> levelAscii = new List<string>();
        for (int y = tilemap.cellBounds.yMin; y < tilemap.cellBounds.yMax; y++)
        {
            string currLine = "";
            for (int x = tilemap.cellBounds.xMin; x < tilemap.cellBounds.xMax; x++)
            {
                Sprite tileSprite = tilemap.GetSprite(new Vector3Int(x,y,0));
                if (tileSprite != null) {
                    switch(tileSprite.name)
                    {
                        case "empty_space":
                            currLine += ' ';
                            break;
                        case "editor_pacman":
                            currLine += '@';
                            break;
                        case "block":
                            currLine += '#';
                            break;
                        case "editor_pellet":
                            currLine += 'o';
                            break;
                        case "editor_pellet_energizer":
                            currLine += 'O';
                            break;
                        case "editor_blinky":
                            currLine += 'B';
                            break;
                        case "editor_inky":
                            currLine += 'I';
                            break;
                        case "editor_pinky":
                            currLine += 'P';
                            break;
                        default:
                            break;
                    }
                }
            }
            if (currLine != "") {
                levelAscii.Add(currLine);
            }
        }
        levelAscii.Reverse();
        File.WriteAllLines(Application.streamingAssetsPath + "/CustomLevel.txt", levelAscii.ToArray());

        // play
        Destroy(GameObject.FindGameObjectWithTag("Game"));
        SceneManager.LoadScene("Play");
    }
}
