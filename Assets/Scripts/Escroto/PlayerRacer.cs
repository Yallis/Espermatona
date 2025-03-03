using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRacer : MonoBehaviour{

    public float drag;
    public float thrust = 250.0f;
    public Swipe swipeControls;

    private Rigidbody2D rb;

    EscrotoControl escrotoControl;
    ClickManager clickmanager;

    private void Awake() {
        clickmanager = GameObject.FindGameObjectWithTag("ClickManager").GetComponent<ClickManager>();
        gameObject.GetComponentInChildren<SpriteRenderer>().color = clickmanager.PlayerColor;
    }

    void Start() {
        escrotoControl = GameObject.FindGameObjectWithTag("EscrotoControl").GetComponent<EscrotoControl>();

        rb = gameObject.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0.0f;
        rb.drag = drag;
    }

    void Update() {
        if (escrotoControl.GetCurrentState == statEscroto.PLAYRACE) {
            if (swipeControls.SwipeRight) {
                rb.AddForce(transform.right * thrust);
                //Debug.Log ("Forward");
            }
            /*if (swipeControls.SwipeUp) {
                rb.AddForce(transform.up * thrust);
                //Debug.Log("UP");
            }
            else if (swipeControls.SwipeDown) {
                rb.AddForce(-transform.up * thrust);
                //Debug.Log("Down");
            }*/
        }
    }
}
