using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRacer : MonoBehaviour{

    public float drag;
    public float obstacleDrag;
    public float thrust = 250.0f;
    public GameObject powerCharger;

    private Rigidbody2D rb;
    private bool onOvulo = false;
    private bool penetrnado = false;

    private float timeDelay = 0.25f;
    private float lastTime;

    private EnemyPowerCharger power;
    private Transform ovuloTransform;

    GameController gameControl;

    void Start(){
        gameControl = GameObject.FindGameObjectWithTag("GameControl").GetComponent<GameController>();
        ovuloTransform = GameObject.FindGameObjectWithTag("Ovulo").transform;

        powerCharger.SetActive(false);
        rb = gameObject.AddComponent<Rigidbody2D>();
		rb.gravityScale = 0.0f;
        rb.drag = drag;

        lastTime = Time.time;

        //power.SetTimeDelay = 0.2f;

        timeDelay = (float)Random.Range(18, 45) / 100;
    }
		
    void Update(){
        if (gameControl.GetCurrentState == stateMachine.PLAY) {
            if (onOvulo) {
                powerCharger.SetActive(penetrnado);
                rb.AddForce(Vector3.Normalize(ovuloTransform.position - transform.position) * (thrust * powerCharger.transform.localScale.x / 10));
            }
            else {
                if (Time.time - lastTime > timeDelay) {
                    rb.AddForce(transform.right * thrust);
                    lastTime = Time.time;
                }
            }
        }
        else powerCharger.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Obstacle")
            rb.drag = obstacleDrag;
        else if (collision.tag == "Ovulo") {
            onOvulo = true;
            penetrnado = true;
            rb.drag = 800;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        rb.drag = drag;
        if (collision.tag == "Ovulo") {
            penetrnado = false;
        }
    }
}
