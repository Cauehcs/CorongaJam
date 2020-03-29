using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscolherGame : MonoBehaviour
{
    public Canvas telaEscolha;
    public Text[] txtNameGame;
    public float index;
    public bool activate;
    public GameObject MainCamera,SnakeCamera, InvadersCamera;
    public static bool inInvaders, inSnake, inMain;
        
    private void Update() {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            mainCamera();
        }
        if (activate) {
            GameObject.Find("player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GameObject.Find("player").GetComponent<playerBehaviour>().enabled = false;
            telaEscolha.enabled = true;
        }
        else {
            index = 0;
            telaEscolha.enabled = false;
            GameObject.Find("player").GetComponent<playerBehaviour>().enabled = true;
        }
        Index();
    }

    void Index() {
        if (Input.GetKeyDown(KeyCode.UpArrow)) index++;
        if (Input.GetKeyDown(KeyCode.DownArrow)) index--;

        if (Input.GetKeyDown(KeyCode.Escape)) activate = false;

        if (index > 1) index = 0;
        else if (index < 0) index = 1;

        if (index == 0) {
            txtNameGame[0].color = Color.yellow;
            txtNameGame[1].color = Color.white;

            if(Input.GetKeyDown(KeyCode.Return) && telaEscolha.enabled == true)
            {
                snakeCamera();
            }
        }
        else if (index == 1) {
            txtNameGame[1].color = Color.yellow;
            txtNameGame[0].color = Color.white;

            if(Input.GetKeyDown(KeyCode.Return) && telaEscolha.enabled == true){
            invadersCamera();}
        }
    }

    public void mainCamera() {
        MainCamera.SetActive(true);
        SnakeCamera.SetActive(false);
        InvadersCamera.SetActive(false);
        inInvaders = false;
        inSnake = true;
        inMain = false;
    }

    public void snakeCamera()
    {
        
        MainCamera.SetActive(false);
        SnakeCamera.SetActive(true);
        InvadersCamera.SetActive(false);
        inInvaders = false;
        inSnake = true;
        inMain = false;
    }

    public void invadersCamera()
    {
        
        MainCamera.SetActive(false);
        SnakeCamera.SetActive(true);
        InvadersCamera.SetActive(true);
        inInvaders = true;
        inSnake = false;
        inMain = false;
    }
}
