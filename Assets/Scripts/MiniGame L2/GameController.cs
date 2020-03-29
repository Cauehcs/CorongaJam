using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static int lifeNave, score;
    public static float time;
    public static bool startGame;

    public GameObject[] navesLife;
    public Image timeGO;
    public Text txtScore;   

    public static void StartGameNave() {
        time = 0;
        lifeNave = 3; time = 0;
        startGame = true;
    }

    private void Update() {
        SetUI();
        if (startGame) {
            startGame = false;
            StartCoroutine(Cronometro());
        }

        if (lifeNave < 1 || GameObject.Find("nave") == null) {
            barsBerraviour.GanharBarra(1, 20); 
            //QuitGame();
        }
        
        if(time >= 30) {
            barsBerraviour.GanharBarra(1, 30);
            //QuitGame(); 
        }
        
    }

    //void QuitGame() => naveScene.SetActive(false);
    

    void SetUI() {
        for (int i = 0; i < navesLife.Length; i++) {
            navesLife[i].SetActive(false);
        }
        for (int i = 0; i < lifeNave; i++) {
            navesLife[i].SetActive(true);
        }

        txtScore.text = "Score: " + score.ToString();
        timeGO.fillAmount = 1 - time/30;  
    }

    IEnumerator Cronometro() {
        yield return new WaitForSeconds(1f);
        time++;
        StartCoroutine(Cronometro());
    }
}
