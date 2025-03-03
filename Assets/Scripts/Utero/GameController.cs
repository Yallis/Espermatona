using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum stateMachine {
    START,
    RELOAD,
    PAUSED,
    PLAY,
    WIN,
    LOSE,
    NULL
}

public class GameController : MonoBehaviour {

    public GameObject startScreen;
    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject pauseScreen;
    public GameObject turorialScreen;
    public Text startTxt;

    private stateMachine currentState = stateMachine.NULL;
    private stateMachine lastState = stateMachine.NULL;

    private float timeToStart = 3.0f;
    private float lastTime;

    void Start() {
        //lastTime = Time.time;
        //GameStart();
    }

    void Update() {
        GameStateMachine();
    }

    void GameStateMachine() {
        switch (currentState) {
            case stateMachine.START: {
                    if ((int)(Time.time - lastTime) == (int)(timeToStart-1)) {
                        startTxt.text = "GO!";
                    } else
                        startTxt.text = "" + (int)(3 - (Time.time - lastTime));

                    if (Time.time - lastTime > timeToStart) {
                        startScreen.SetActive(false);
                        SwitchState(stateMachine.PLAY);
                    }
                }
                break;
            case stateMachine.RELOAD: {
                    //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
                break;
            case stateMachine.PAUSED: {
                    pauseScreen.SetActive(true);
                    Time.timeScale = 0;
                    BasicInputs();
                }
                break;
            case stateMachine.PLAY: {
                    pauseScreen.SetActive(false);
                    Time.timeScale = 1;
                    BasicInputs();
                }
                break;
            case stateMachine.WIN: {
                    Debug.Log("YOU WIN!");
                    Time.timeScale = 0;
                    winScreen.SetActive(true);
                    //SceneManager.LoadScene ("WinScreen");
                }
                break;
            case stateMachine.LOSE: {
                    Debug.Log("YOU LOSE!");
                    Time.timeScale = 0;
                    loseScreen.SetActive(true);
                    //failScreen.SetActive(true);
                }
                break;
        }
    }

    public void SwitchState(stateMachine nextState) {
        lastState = currentState;
        currentState = nextState;
    }

    public stateMachine GetCurrentState { get { return currentState; } }
    public stateMachine GetLastState { get { return lastState; } }

    void BasicInputs() {
        if (Input.GetKeyDown(KeyCode.Escape) && currentState == stateMachine.PLAY) {
            currentState = stateMachine.PAUSED;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && currentState == stateMachine.PAUSED) {
            currentState = stateMachine.PLAY;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && currentState == stateMachine.NULL) {
            ToMenu();
        }
        else if (Input.GetKeyDown(KeyCode.R)) {
            currentState = stateMachine.RELOAD;
        }
    }

    public void GameStart() {
        lastTime = Time.time;
        turorialScreen.SetActive(false);
        startScreen.transform.GetChild(0).gameObject.SetActive(true);
        currentState = stateMachine.START;
    }

    public void Pause() {
        SwitchState(stateMachine.PAUSED);
    }

    public void Continue() {
        SwitchState(stateMachine.PLAY);
        //currentState = stateMachine.PLAY;
    }

    public void Reload() {
        SwitchState(stateMachine.RELOAD);
    }

    public void Win() {
        SwitchState(stateMachine.WIN);
    }

    public void Lose() {
        SwitchState(stateMachine.LOSE);
    }

    public void Exit() {
        Application.Quit();
    }

    public void ToMenu() {
        SceneManager.LoadScene ("Menu");
    }

    public stateMachine CurrentState{
        get { return currentState; }
    }

    public void CloseScreen(GameObject screenGO) {
        screenGO.SetActive(false);
        Continue();
    }
}
