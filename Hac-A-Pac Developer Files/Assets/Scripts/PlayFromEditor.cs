using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class PlayFromEditor : MonoBehaviour
{
    public Tilemap tilemap;

    public void SaveLevelAndPlay() 
    {
        // save level
        Debug.Log(tilemap.cellBounds.xMin);
        Debug.Log(tilemap.cellBounds.xMax);
        Debug.Log(tilemap.cellBounds.yMin);
        Debug.Log(tilemap.cellBounds.yMax);
        //string[] levelAscii = new string[tilemap.cellBounds.xMax - tilemap.cellBounds.xMin];
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
                        case "pacman_2":
                            currLine += '@';
                            break;
                        case "block":
                            currLine += '#';
                            break;
                        case "pellet":
                            currLine += 'o';
                            break;
                        case "pellet_energizer":
                            currLine += 'O';
                            break;
                        case "editor_characters_47":
                            currLine += 'B';
                            break;
                        case "editor_characters_70":
                            currLine += 'I';
                            break;
                        case "editor_characters_53":
                            currLine += 'P';
                            break;
                        default:
                            break;
                    }
                }
            }
            //levelAscii[x - tilemap.cellBounds.xMin] = currLine;
            if (currLine != "") {
                levelAscii.Add(currLine);
            }
        }
        levelAscii.Reverse();
        File.WriteAllLines(Application.streamingAssetsPath + "/TestLevel.txt", levelAscii.ToArray());

        // play
        Destroy(GameObject.FindGameObjectWithTag("Game"));
        SceneManager.LoadScene(1);
    }
}
