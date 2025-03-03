using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceFinish : MonoBehaviour{

    GameController gameControl;

    void Start(){
        gameControl = GameObject.FindGameObjectWithTag("GameControl").GetComponent<GameController>();
    }


    void Update(){
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player")
            gameControl.Win();
        else
            gameControl.Lose();
    }
}
