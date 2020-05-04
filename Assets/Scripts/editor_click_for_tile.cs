using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class editor_click_for_tile : MonoBehaviour
{
    public GameObject tool;

    // creates instance of tool at location of mouse pointer
    public void Spawn(Vector3 position) {
        instantiate(tool).transform.position = position;
    }

    // Update is called once per frame
    public void Update()
    {
        // if left mouse is clicked
        if (Input.GetKeyDown(KeyCode.Mouse0) {
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition, Camera.MonoOrSteroscopicEye.Mono);

            // Make Z position the Z position of the prefab object
            Vector3 adjustZ = new Vector3(worldPoint.x, worldPoint.y, tool.transform.position.z);

            Spawn(adjustZ);
        }
    }
}
