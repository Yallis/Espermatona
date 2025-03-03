using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espermatozoido : MonoBehaviour{

    public Collider2D[] sensors = new Collider2D[2];
    public LayerMask collisionTargetMask;
    public ClickManager clickManager;

    private Rigidbody2D rb;

    public float ang, angulo;
    float vel = 1.5f;
    //float currentVel = 1.5f;
    Vector2 dir = Vector2.right;

    void Start() {
        rb = gameObject.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0.0f;

        angulo = ang = transform.eulerAngles.z;
    }


    private void Update() {
        
    }

    void FixedUpdate() {
        angulo = Mathf.Lerp(angulo, ang, 0.2f);
        transform.rotation = Quaternion.Euler(0, 0, angulo);
        dir = transform.rotation * Vector2.right;


        if (Mathf.Round(angulo) == Mathf.Round(ang)) {
            if (Physics2D.IsTouchingLayers(sensors[0], collisionTargetMask)) {
                ang -= 120 + Random.Range(-35, 35);
            }
            else if (Physics2D.IsTouchingLayers(sensors[1], collisionTargetMask)) {
                ang += 120 + Random.Range(-35, 35);
            }
        }

        rb.velocity = dir * vel;
    }
}
