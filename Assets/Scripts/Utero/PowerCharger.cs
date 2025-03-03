using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCharger : MonoBehaviour{

    public float maxScale;

    GameController gameControl;

    void Start(){
        gameControl = GameObject.FindGameObjectWithTag("GameControl").GetComponent<GameController>();
    }


    void FixedUpdate(){
        if (transform.localScale.x > 1.0f) {
            Vector3 scaleLocal = new Vector3(Mathf.Lerp(transform.localScale.x, 1.0f, 0.05f), Mathf.Lerp(transform.localScale.y, 1.0f, 0.05f), 0);
            transform.localScale = scaleLocal;
        }

        if (gameControl.CurrentState == stateMachine.PLAY) {
            if (Input.GetMouseButtonDown(0)) {
                Vector3 scaleLocal = new Vector3(Mathf.Lerp(transform.localScale.x, maxScale, 0.3f), Mathf.Lerp(transform.localScale.y, maxScale, 0.3f), 0);
                transform.localScale = scaleLocal;
            }
        }
    }
}
