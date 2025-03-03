using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour{

    private string targetTag = null;
    private bool characterSelected = false;
    private GameObject playerChar;
    private static Color playerColor;

    EscrotoControl escrotoControl;

    void Start(){
        escrotoControl = GameObject.FindGameObjectWithTag("EscrotoControl").GetComponent<EscrotoControl>();
    }

    void Update(){
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition), Mathf.Infinity);
            if (hit.collider != null) {
                targetTag = hit.collider.tag;
                if (targetTag == "Espermatozoido") {
                    if (characterSelected) {
                        escrotoControl.DesafioScreen = true;
                    }
                    else {
                        escrotoControl.SelectScreen = true;
                        playerChar = hit.transform.gameObject;
                    }
                }
            }
        }
    }

    public string TargetTag {
        get { return targetTag; }
    }

    public void SelectChar() {
        playerChar.name = "Player";
        playerChar.tag = "Player";
        playerChar.transform.parent = GameObject.FindGameObjectWithTag("EscrotoGO").transform;
        playerColor = Random.ColorHSV();
        playerChar.GetComponentInChildren<SpriteRenderer>().color = playerColor;
        characterSelected = true;
        escrotoControl.SelectScreen = false;

        PlayerStats.PlayerColor = playerColor;
    }

    public Color PlayerColor {
        get { return playerColor; }
    }
}
