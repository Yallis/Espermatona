using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrag : MonoBehaviour{

    private Vector3 dragOrigin;

    void Start(){
        
    }


    void Update(){
        if (Input.GetMouseButtonDown(0)) {
            dragOrigin = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            dragOrigin = Camera.main.ScreenToWorldPoint(dragOrigin);

        } else if (Input.GetMouseButton(0)) {
            Vector3 mouseMove = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            mouseMove = Camera.main.ScreenToWorldPoint(mouseMove);

            Vector3 cameraPos = transform.position - (mouseMove - dragOrigin);

            if (cameraPos.x > 2.45f)
                cameraPos.x = 2.45f;
            else if (cameraPos.x < -2.45f)
                cameraPos.x = -2.45f;
            if (cameraPos.y > 1.4f)
                cameraPos.y = 1.4f;
            else if (cameraPos.y < -1.4f)
                cameraPos.y = -1.4f;

            transform.position = cameraPos;
        }
    }
}
