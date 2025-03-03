using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRace : MonoBehaviour{

    public Transform playerTransform;

    private bool follow = false;

    void Start(){
        
    }


    void Update(){
        if (follow){
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, playerTransform.position.x+3, 0.05f), transform.position.y, transform.position.z);
        } else if(Mathf.Abs(playerTransform.position.x - transform.position.x) < 2){
            follow = true;
        }
    }
}
