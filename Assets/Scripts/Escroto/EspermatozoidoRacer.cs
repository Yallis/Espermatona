using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspermatozoidoRacer : MonoBehaviour{

    public float drag;
    public float thrust = 250.0f;

    private Rigidbody2D rb;

    private float timeDelay = 0.25f;
    private float lastTime;

    private EnemyPowerCharger power;
    private Transform ovuloTransform;

    EscrotoControl escrotoControl;

    void Start() {
        escrotoControl = GameObject.FindGameObjectWithTag("EscrotoControl").GetComponent<EscrotoControl>();

        rb = gameObject.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0.0f;
        rb.drag = drag;
    }

    void Update() {
        if (escrotoControl.GetCurrentState == statEscroto.STARTRACE) {
            lastTime = Time.time;

            timeDelay = (float)Random.Range(15, 25) / 100;
            Debug.Log("" + timeDelay);
        }
        else if (escrotoControl.GetCurrentState == statEscroto.PLAYRACE) {
            if (Time.time - lastTime > timeDelay) {
                rb.AddForce(transform.right * thrust);
                lastTime = Time.time;
            }
        }
    }
}
