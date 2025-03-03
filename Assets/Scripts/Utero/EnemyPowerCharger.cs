using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPowerCharger : MonoBehaviour{

    public float maxScale;

    private float timeDelay;
    private float lastTime;

    void Start() {
        lastTime = Time.time;

        timeDelay = (float)Random.Range(16, 30) / 100;
    }


    void FixedUpdate() {
        if (transform.localScale.x > 1.0f) {
            Vector3 scaleLocal = new Vector3(Mathf.Lerp(transform.localScale.x, 1.0f, 0.05f), Mathf.Lerp(transform.localScale.y, 1.0f, 0.05f), 0);
            transform.localScale = scaleLocal;
        }

        if (Time.time - lastTime > timeDelay) {
            Vector3 scaleLocal = new Vector3(Mathf.Lerp(transform.localScale.x, maxScale, 0.3f), Mathf.Lerp(transform.localScale.y, maxScale, 0.3f), 0);
            transform.localScale = scaleLocal;
            //Vector3 scaleLocal = new Vector3( transform.localScale.x + 0.6f, transform.localScale.y + 0.6f, 0);
            //transform.localScale = scaleLocal;
            lastTime = Time.time;
        }
    }

    public float SetTimeDelay {
        set { timeDelay = value; }
    }
}
