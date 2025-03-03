using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum statEscroto {
    START,
    RELOAD,
    PAUSED,
    PLAY,
    STARTRACE,
    PLAYRACE,
    FINISHRACE,
    NULL
}

public class EscrotoControl : MonoBehaviour{

    public GameObject startGameScreen;
    public GameObject desafioScreen;
    public GameObject pauseScreen;
    public GameObject selectScreen;
    public GameObject selectAnotherScreen;
    public GameObject escrotoGO;
    public GameObject raceStartScreen;
    public GameObject raceGO;
    public GameObject raceElements;
    public GameObject endRaceScreen;

    public GameObject nVitoriasTxt;

    private statEscroto currentState = statEscroto.NULL;
    private statEscroto lastState = statEscroto.NULL;

    private int nVitorias = 0;

    void Start() {
        nVitoriasTxt.GetComponent<Text>().text = "" + nVitorias + " / 3";
        //GameStart();
    }

    void Update() {
        GameStateMachine();

        if (nVitorias == 3) {
            SceneManager.LoadScene("UteroScene");
        }
    }

    void GameStateMachine() {
        switch (currentState) {
            case statEscroto.START: {
                    //startScreen.SetActive(false);
                    SwitchState(statEscroto.PLAY);
                }
                break;
            case statEscroto.RELOAD: {
                    //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
                break;
            case statEscroto.PAUSED: {
                    pauseScreen.SetActive(true);
                    Time.timeScale = 0;
                    BasicInputs();
                }
                break;
            case statEscroto.PLAY: {
                    pauseScreen.SetActive(false);
                    nVitoriasTxt.SetActive(true);
                    Time.timeScale = 1;
                    BasicInputs();
                }
                break;
            case statEscroto.STARTRACE: {
                    nVitoriasTxt.SetActive(false);
                }
                break;
        }
    }

    public void SwitchState(statEscroto nextState) {
        lastState = currentState;
        currentState = nextState;
    }

    public statEscroto GetCurrentState { get { return currentState; } }
    public statEscroto GetLastState { get { return lastState; } }

    void BasicInputs() {
        if (Input.GetKeyDown(KeyCode.Escape) && currentState == statEscroto.PLAY) {
            if (desafioScreen.activeSelf)
                desafioScreen.SetActive(false);
            else
                currentState = statEscroto.PAUSED;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && currentState == statEscroto.PAUSED) {
            currentState = statEscroto.PLAY;
        }
        else if (Input.GetKeyDown(KeyCode.R)) {
            currentState = statEscroto.RELOAD;
        }
    }

    public void GameStart() {
        startGameScreen.SetActive(false);
        currentState = statEscroto.START;
    }

    public void Pause() {
        SwitchState(statEscroto.PAUSED);
    }

    public void Continue() {
        SwitchState(statEscroto.PLAY);
    }

    public void Reload() {
        SwitchState(statEscroto.RELOAD);
    }

    public void StartRace() {
        escrotoGO.SetActive(false);
        desafioScreen.SetActive(false);
        raceGO.SetActive(true);
        raceElements.SetActive(true);
        raceStartScreen.SetActive(true);
        SwitchState(statEscroto.STARTRACE);
    }

    public void PlayRace() {
        raceStartScreen.SetActive(false);
        SwitchState(statEscroto.PLAYRACE);
    }

    public void EndRace(string endTxt) {
        endRaceScreen.transform.GetChild(0).GetComponent<Text>().text = endTxt;
        endRaceScreen.SetActive(true);
        SwitchState(statEscroto.FINISHRACE);
    }

    public void VoltarAoSaco() {
        endRaceScreen.SetActive(false);
        escrotoGO.SetActive(true);
        raceGO.SetActive(false);
        raceElements.SetActive(false);
        Camera.main.transform.position = new Vector3(0, 0, Camera.main.transform.position.z);
        Camera.main.GetComponent<CameraDrag>().enabled = true;
        Camera.main.GetComponent<CameraRace>().enabled = false;
        nVitoriasTxt.GetComponent<Text>().text = "" + nVitorias + " / 3";
        SwitchState(statEscroto.PLAY);

    }

    public void Exit() {
        Application.Quit();
    }

    public void ToMenu() {
        SceneManager.LoadScene ("Menu");
    }

    public bool SelectScreen {
        set { selectScreen.SetActive(value); }
    }

    public void SelectAnotherScreen(bool b) {
        selectAnotherScreen.SetActive(b);
        selectScreen.SetActive(!b);
    }

    public bool DesafioScreen {
        set { desafioScreen.SetActive(value); }
    }

    public int NVitoriasIncrease {
        set { nVitorias = value; }
    }

    public int NVitorias {
        get { return nVitorias; }
    }

    public void CloseScreen(GameObject screenGO) {
        screenGO.SetActive(false);
        Continue();
    }
}
