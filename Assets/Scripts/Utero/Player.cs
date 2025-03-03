using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{

    public float drag;
    public float obstacleDrag;
    public float thrust = 250.0f;
    public GameObject powerCharger;
    public Transform ovuloTransform;
    public Swipe swipeControls;

    private Rigidbody2D rb;
    private bool onOvulo = false;

    GameController gameControl;

    void Start(){
        gameControl = GameObject.FindGameObjectWithTag("GameControl").GetComponent<GameController>();

        powerCharger.SetActive(false);
		rb = GetComponent<Rigidbody2D>();
        rb.drag = drag;

        //if(PlayerStats.PlayerColor != null)
        gameObject.GetComponentInChildren<SpriteRenderer>().color = PlayerStats.PlayerColor;
    }
		
    void Update(){
        if (gameControl.CurrentState == stateMachine.PLAY) {
            if (onOvulo) {
                powerCharger.SetActive(true);
                rb.AddForce(Vector3.Normalize(ovuloTransform.position - transform.position) * (thrust * powerCharger.transform.localScale.x /10));
            }
            else {
                if (swipeControls.SwipeRight) {
                    rb.AddForce(transform.right * thrust);
                    //Debug.Log ("Forward");
                }
                if (swipeControls.SwipeUp) {
                    rb.AddForce(transform.up * thrust);
                    //Debug.Log("UP");
                }
                else if (swipeControls.SwipeDown) {
                    rb.AddForce(-transform.up * thrust);
                    //Debug.Log("Down");
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Obstacle")
            rb.drag = obstacleDrag;
        else if (collision.tag == "Ovulo") {
            onOvulo = true;
            rb.drag = 800;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        rb.drag = drag;
    }
}
