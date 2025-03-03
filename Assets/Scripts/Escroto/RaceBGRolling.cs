using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceBGRolling : MonoBehaviour {

    public float offset;
    [Range(0.0f, 0.1f)]
    public float speedParallax;
    public bool flipado;

    private Material currentMateria;

    void Awake() {
        currentMateria = GetComponent<Renderer>().material;
        if (flipado) speedParallax = -speedParallax;
    }

    void FixedUpdate() {
        currentMateria.SetTextureOffset("_MainTex", new Vector2((transform.position.x + offset) * speedParallax, 0));
    }
}
