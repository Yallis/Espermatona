using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RaceController : MonoBehaviour{

    public Text startTxt;
    public GameObject playerRacer;
    public GameObject enemyRacer;
    public Transform playerStartRacePoint;
    public Transform enemyStartRacePoint;
    public LayerMask playerLayerMask;
    public LayerMask enemyLayerMask;


    //private GameObject raceElements;
    private Collider2D chegadaCollider;
    private float timeToStart = 3.0f;
    private float lastTime;

    EscrotoControl escrotoControl;

    void Start(){
        escrotoControl = GameObject.FindGameObjectWithTag("EscrotoControl").GetComponent<EscrotoControl>();
        chegadaCollider = transform.GetChild(0).transform.GetComponentInChildren<Collider2D>();
    }


    void Update(){
        if(escrotoControl.GetCurrentState == statEscroto.STARTRACE) {
            if ((int)(Time.time - lastTime) == (int)(timeToStart - 1)) {
                startTxt.text = "GO!";
            }
            else
                startTxt.text = "" + (int)(3 - (Time.time - lastTime));

            if (Time.time - lastTime > timeToStart) {
                escrotoControl.PlayRace();
            }
        }

        if (escrotoControl.GetCurrentState == statEscroto.PLAYRACE) {
            if (Physics2D.IsTouchingLayers(chegadaCollider, playerLayerMask)) {
                RaceFinish("Você venceu!");
                escrotoControl.NVitoriasIncrease = escrotoControl.NVitorias + 1;
                Debug.Log("Venceu!");
            }
            else if (Physics2D.IsTouchingLayers(chegadaCollider, enemyLayerMask)) {
                RaceFinish("Você foi derrotado");
                Debug.Log("Perdeu!");
            }
        }
    }

    public void StartRace() {
        lastTime = Time.time;

        enemyRacer.transform.position = enemyStartRacePoint.position;
        playerRacer.transform.position = playerStartRacePoint.position;

        Camera.main.transform.position = new Vector3(0 , 0, Camera.main.transform.position.z) ;
        Camera.main.GetComponent<CameraDrag>().enabled = false;
        Camera.main.GetComponent<CameraRace>().enabled = true;

        escrotoControl.StartRace();
    }

    public void RaceFinish(string txt) {
        escrotoControl.EndRace(txt);
    }
}
