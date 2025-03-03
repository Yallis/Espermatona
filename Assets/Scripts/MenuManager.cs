using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour{

    void Start(){
        Time.timeScale = 1;
    }

    public void PlayGame() {
        SceneManager.LoadScene("EscrotoScene");
    }

    public void ToMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void Creditos() {
        SceneManager.LoadScene("Creditos");
    }

    public void ExitGame() {
        Application.Quit();
    }
}
