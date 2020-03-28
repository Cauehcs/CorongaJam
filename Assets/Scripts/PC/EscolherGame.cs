using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscolherGame : MonoBehaviour
{
    public GameObject[] cameras;

    public static bool savePlayer;
    public Canvas telaEscolha;
    public Text[] txtNameGame;
    public float index;
    public bool activate;

    private void Update() {
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
        if(Input.GetKeyDown(KeyCode.Return)) SetGame(index);
    }

    void SetGame(float game) {
        savePlayer = true;
        
        cameras[0].SetActive(false);
        cameras[1].SetActive(false);

        if (game == 0) {
            this.enabled = false;
            SceneManager.LoadScene("snakePedro");
        }

        if (game == 1) {
            this.enabled = false;
            GameController.StartGameNave();
        }
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
        }
        else if (index == 1) {
            txtNameGame[1].color = Color.yellow;
            txtNameGame[0].color = Color.white;
        }
    }
}
