using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickTimeGeneratorCozinha : MonoBehaviour
{
    [SerializeField] string[] teclasQuickTime;
    [SerializeField] string teclaSelecionada, ultimaTecla;

    [SerializeField] Image[] btns;

    public float pontosMaximo;
    public GameObject[] canvas;
    public static GameObject[] canvasa = new GameObject[4];

    public float tempoTrocaTecla;
    static float tempoAtual;

    public float ptn, erros;

    public static void StartGame() {
        tempoAtual = 0;
        canvasa[0].SetActive(true);
        canvasa[1].SetActive(true);
        canvasa[3].GetComponent<Animator>().SetBool("sucesso", false);
        canvasa[3].GetComponent<Animator>().SetBool("fracasso", false);
        canvasa[2].GetComponent<Animator>().SetBool("reset", false);
        canvasa[3].GetComponent<Animator>().SetBool("reset", false);
    }


    void resetGame() {
        GameObject.Find("player").GetComponent<playerBehaviour>().enabled = true;
        tempoAtual = 0;
        canvas[2].GetComponent<Animator>().SetBool("reset", true);
        canvas[3].GetComponent<Animator>().SetBool("reset", true);
        canvas[0].SetActive(false);
        canvas[1].SetActive(false);
        ptn = 0; teclaSelecionada = null;
        erros = 0; ultimaTecla = null;
        GetComponent<QuickTimeGeneratorCozinha>().enabled = false;
    }

    void GanhouGame() {
        canvas[3].GetComponent<Animator>().SetBool("sucesso", true);
        StartCoroutine(tempoPausa());
    }

    IEnumerator tempoPausa() {
        yield return new WaitForSeconds(1f);
        resetGame();
    }

    void PerdeuGame() {
        canvas[3].GetComponent<Animator>().SetBool("fracasso", true);
        StartCoroutine(tempoPausa());
    }

    private void Awake() {
        canvasa[0] = canvas[0];
        canvasa[1] = canvas[1];
        canvasa[2] = canvas[2];
        canvasa[3] = canvas[3];
    }

    private void Update() {

        InputKeyboard();
        GameObject.Find("player").GetComponent<playerBehaviour>().enabled = false;

        if (ptn >= pontosMaximo) GanhouGame();
        if (erros > 2) PerdeuGame();

        if(tempoAtual >= tempoTrocaTecla) {
            ultimaTecla = teclaSelecionada;
            tempoAtual = 0; RandomTeclas();
            if (ultimaTecla == teclaSelecionada) {
                tempoAtual = 0;
                RandomTeclas();
            }
        }
        else {
            tempoAtual += Time.deltaTime;
        }
    }

    void InputKeyboard() {

        if (Input.GetKeyDown(KeyCode.Z) && teclaSelecionada == "z") {
            RandomTeclas(); ptn++;
            if (ultimaTecla == teclaSelecionada) {
                tempoAtual = 0;
                RandomTeclas();
            }
            tempoAtual = 0;
        }
        if (Input.GetKeyDown(KeyCode.X) && teclaSelecionada == "x") {
            tempoAtual = 0;
            RandomTeclas(); ptn++;
            if (ultimaTecla == teclaSelecionada) {
                tempoAtual = 0;
                RandomTeclas();
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && teclaSelecionada == "cima") {
            RandomTeclas(); ptn++;
            if (ultimaTecla == teclaSelecionada) {
                tempoAtual = 0;
                RandomTeclas();
            }
            tempoAtual = 0;
            
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && teclaSelecionada == "baixo") {
            RandomTeclas(); ptn++;
            if (ultimaTecla == teclaSelecionada) {
                tempoAtual = 0;
                RandomTeclas();
            }
            tempoAtual = 0;
            
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && teclaSelecionada == "esquerda") {
            tempoAtual = 0;
            RandomTeclas(); ptn++;
            if (ultimaTecla == teclaSelecionada) {
                tempoAtual = 0;
                RandomTeclas();
            }
            
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && teclaSelecionada == "direita") {
            tempoAtual = 0;
            RandomTeclas(); ptn++;
            if (ultimaTecla == teclaSelecionada) {
                tempoAtual = 0;
                RandomTeclas();
            }
            
        }


        if (Input.GetKeyDown(KeyCode.Z) && teclaSelecionada != "z") {
            RandomTeclas(); erros++;
            if (ultimaTecla == teclaSelecionada) {
                tempoAtual = 0;
                RandomTeclas();
            }
            tempoAtual = 0;
        }
        if (Input.GetKeyDown(KeyCode.X) && teclaSelecionada != "x") {
            tempoAtual = 0;
            RandomTeclas(); erros++;
            if (ultimaTecla == teclaSelecionada) {
                tempoAtual = 0;
                RandomTeclas();
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && teclaSelecionada != "cima") {
            RandomTeclas(); erros++;
            if (ultimaTecla == teclaSelecionada) {
                tempoAtual = 0;
                RandomTeclas();
            }
            tempoAtual = 0;

        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && teclaSelecionada != "baixo") {
            RandomTeclas(); erros++;
            if (ultimaTecla == teclaSelecionada) {
                tempoAtual = 0;
                RandomTeclas();
            }
            tempoAtual = 0;

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && teclaSelecionada != "esquerda") {
            tempoAtual = 0;
            RandomTeclas(); erros++;
            if (ultimaTecla == teclaSelecionada) {
                tempoAtual = 0;
                RandomTeclas();
            }

        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && teclaSelecionada != "direita") {
            tempoAtual = 0;
            RandomTeclas(); erros++;
            if (ultimaTecla == teclaSelecionada) {
                tempoAtual = 0;
                RandomTeclas();
            }

        }
    }

    void RandomTeclas() {
        teclaSelecionada = teclasQuickTime[Random.Range(0, teclasQuickTime.Length)];

        if(teclaSelecionada == "x") {
            btns[1].color = new Vector4(btns[1].color.r, btns[1].color.g, btns[1].color.b, 1) ;
            btns[2].color = new Vector4(btns[2].color.r, btns[2].color.g, btns[2].color.b, 0.35f);
            btns[3].color = new Vector4(btns[3].color.r, btns[3].color.g, btns[3].color.b, 0.35f);
            btns[4].color = new Vector4(btns[4].color.r, btns[4].color.g, btns[4].color.b, 0.35f);
            btns[5].color = new Vector4(btns[5].color.r, btns[5].color.g, btns[5].color.b, 0.35f);
            btns[0].color = new Vector4(btns[0].color.r, btns[0].color.g, btns[0].color.b, 0.35f);
        }
        if (teclaSelecionada == "z") {
            btns[1].color = new Vector4(btns[1].color.r, btns[1].color.g, btns[1].color.b, 0.35f);
            btns[2].color = new Vector4(btns[2].color.r, btns[2].color.g, btns[2].color.b, 0.35f);
            btns[3].color = new Vector4(btns[3].color.r, btns[3].color.g, btns[3].color.b, 0.35f);
            btns[4].color = new Vector4(btns[4].color.r, btns[4].color.g, btns[4].color.b, 0.35f);
            btns[5].color = new Vector4(btns[5].color.r, btns[5].color.g, btns[5].color.b, 0.35f);
            btns[0].color = new Vector4(btns[0].color.r, btns[0].color.g, btns[0].color.b, 1);
        }
        if (teclaSelecionada == "cima") {
            btns[1].color = new Vector4(btns[1].color.r, btns[1].color.g, btns[1].color.b, 0.35f);
            btns[2].color = new Vector4(btns[2].color.r, btns[2].color.g, btns[2].color.b, 1);
            btns[3].color = new Vector4(btns[3].color.r, btns[3].color.g, btns[3].color.b, 0.35f);
            btns[4].color = new Vector4(btns[4].color.r, btns[4].color.g, btns[4].color.b, 0.35f);
            btns[5].color = new Vector4(btns[5].color.r, btns[5].color.g, btns[5].color.b, 0.35f);
            btns[0].color = new Vector4(btns[0].color.r, btns[0].color.g, btns[0].color.b, 0.35f);
        }
        if (teclaSelecionada == "esquerda") {
            btns[1].color = new Vector4(btns[1].color.r, btns[1].color.g, btns[1].color.b, 0.35f);
            btns[2].color = new Vector4(btns[2].color.r, btns[2].color.g, btns[2].color.b, 0.35f);
            btns[3].color = new Vector4(btns[3].color.r, btns[3].color.g, btns[3].color.b, 1);
            btns[4].color = new Vector4(btns[4].color.r, btns[4].color.g, btns[4].color.b, 0.35f);
            btns[5].color = new Vector4(btns[5].color.r, btns[5].color.g, btns[5].color.b, 0.35f);
            btns[0].color = new Vector4(btns[0].color.r, btns[0].color.g, btns[0].color.b, 0.35f);
        }
        if (teclaSelecionada == "direita") {
            btns[1].color = new Vector4(btns[1].color.r, btns[1].color.g, btns[1].color.b, 0.35f);
            btns[2].color = new Vector4(btns[2].color.r, btns[2].color.g, btns[2].color.b, 0.35f);
            btns[3].color = new Vector4(btns[3].color.r, btns[3].color.g, btns[3].color.b, 0.35f);
            btns[4].color = new Vector4(btns[4].color.r, btns[4].color.g, btns[4].color.b, 0.35f);
            btns[5].color = new Vector4(btns[5].color.r, btns[5].color.g, btns[5].color.b, 1);
            btns[0].color = new Vector4(btns[0].color.r, btns[0].color.g, btns[0].color.b, 0.35f);
        }
        if (teclaSelecionada == "baixo") {
            btns[1].color = new Vector4(btns[1].color.r, btns[1].color.g, btns[1].color.b, 0.35f);
            btns[2].color = new Vector4(btns[2].color.r, btns[2].color.g, btns[2].color.b, 0.35f);
            btns[3].color = new Vector4(btns[3].color.r, btns[3].color.g, btns[3].color.b, 0.35f);
            btns[4].color = new Vector4(btns[4].color.r, btns[4].color.g, btns[4].color.b, 1);
            btns[5].color = new Vector4(btns[5].color.r, btns[5].color.g, btns[5].color.b, 0.35f);
            btns[0].color = new Vector4(btns[0].color.r, btns[0].color.g, btns[0].color.b, 0.35f);
        }
    }
}
