using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour{

    public GameObject enemy;

    private bool startou = false;
    private GameObject spawnPointsList;
    //List<Transform> spawnPoints = new List<Transform>();

    GameController gameControl;

    void Start(){
        gameControl = GameObject.FindGameObjectWithTag("GameControl").GetComponent<GameController>();
        spawnPointsList = GameObject.FindGameObjectWithTag("Points");
    }


    void Update(){
        if(gameControl.startTxt.text == "GO!" && !startou) {
            Startar();
        }
    }

    private void Startar() {
        foreach (Transform point in spawnPointsList.transform) {
            float xSp = (float)Random.Range(-2, 2) / 10;
            float ySp = (float)Random.Range(-2, 2) / 10;
            Vector3 spawnPosition = new Vector3(point.transform.position.x + xSp, point.transform.position.y + ySp, 0);

            GameObject newEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity);
            newEnemy.transform.parent = gameObject.transform;

            startou = true;
        }
    }
}
