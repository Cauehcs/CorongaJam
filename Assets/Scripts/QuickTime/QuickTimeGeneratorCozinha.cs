using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickTimeGeneratorCozinha : MonoBehaviour
{
    [SerializeField] string[] teclasQuickTime;
    [SerializeField] string teclaSelecionada, ultimaTecla;


    [SerializeField] Image[] btns;

    public GameObject[] listras;

    public float pontosMaximo;
    public GameObject[] canvas;
    public static GameObject[] canvasa = new GameObject[4];

    public float tempoTrocaTecla;
    static float tempoAtual, aux;

    public float ptn, erros;

    public static void StartGame() {
        tempoAtual = 0;
        aux = 0;
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
        GameObject.Find("player").GetComponent<Animator>().enabled = true;
        erros = -1; ultimaTecla = null;
        GetComponent<QuickTimeGeneratorCozinha>().enabled = false;
    }

    void GanhouGame() {
        btns[1].color = new Vector4(btns[1].color.r, btns[1].color.g, btns[1].color.b, 0.35f);
        btns[2].color = new Vector4(btns[2].color.r, btns[2].color.g, btns[2].color.b, 0.35f);
        btns[3].color = new Vector4(btns[3].color.r, btns[3].color.g, btns[3].color.b, 0.35f);
        btns[4].color = new Vector4(btns[4].color.r, btns[4].color.g, btns[4].color.b, 0.35f);
        btns[5].color = new Vector4(btns[5].color.r, btns[5].color.g, btns[5].color.b, 0.35f);
        btns[0].color = new Vector4(btns[0].color.r, btns[0].color.g, btns[0].color.b, 0.35f);
        canvas[3].GetComponent<Animator>().SetBool("sucesso", true);

        listras[0].SetActive(true);
        listras[1].SetActive(true);

        StartCoroutine(tempoPausa());
        if (aux == 0) {
            barsBerraviour.PerderBarra(1, 50);
            barsBerraviour.GanharBarra(0, 15);
            aux++;
        }
    }

    IEnumerator tempoPausa() {
        yield return new WaitForSeconds(1f);
        resetGame(); 
    }

    void PerdeuGame() {
        btns[1].color = new Vector4(btns[1].color.r, btns[1].color.g, btns[1].color.b, 0.35f);
        btns[2].color = new Vector4(btns[2].color.r, btns[2].color.g, btns[2].color.b, 0.35f);
        btns[3].color = new Vector4(btns[3].color.r, btns[3].color.g, btns[3].color.b, 0.35f);
        btns[4].color = new Vector4(btns[4].color.r, btns[4].color.g, btns[4].color.b, 0.35f);
        btns[5].color = new Vector4(btns[5].color.r, btns[5].color.g, btns[5].color.b, 0.35f);
        btns[0].color = new Vector4(btns[0].color.r, btns[0].color.g, btns[0].color.b, 0.35f);
        canvas[3].GetComponent<Animator>().SetBool("fracasso", true);
        StartCoroutine(tempoPausa());
        if (aux == 0) {
            barsBerraviour.PerderBarra(1, 25);
            barsBerraviour.PerderBarra(0, 15);
            aux++;
        }
    }


    private void Awake() {
        canvasa[0] = canvas[0];
        canvasa[1] = canvas[1];
        canvasa[2] = canvas[2];
        canvasa[3] = canvas[3];
    }

    private void Update() {
        InputKeyboard();
        GameObject.Find("player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
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

        if (Input.GetKeyDown(KeyCode.Z)) { 
            if (teclaSelecionada == "z") {
                RandomTeclas(); ptn++;
                if (ultimaTecla == teclaSelecionada) {
                    tempoAtual = 0;
                    RandomTeclas();
                }
                tempoAtual = 0;
            }
            else {
                RandomTeclas(); erros++;
                if (ultimaTecla == teclaSelecionada) {
                    tempoAtual = 0;
                    RandomTeclas();
                }
                tempoAtual = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.X)) {
            if (teclaSelecionada == "x") {
                RandomTeclas(); ptn++;
                if (ultimaTecla == teclaSelecionada) {
                    tempoAtual = 0;
                    RandomTeclas();
                }
                tempoAtual = 0;
            }
            else {
                RandomTeclas(); erros++;
                if (ultimaTecla == teclaSelecionada) {
                    tempoAtual = 0;
                    RandomTeclas();
                }
                tempoAtual = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            if (teclaSelecionada == "cima") {
                RandomTeclas(); ptn++;
                if (ultimaTecla == teclaSelecionada) {
                    tempoAtual = 0;
                    RandomTeclas();
                }
                tempoAtual = 0;
            }
            else {
                RandomTeclas(); erros++;
                if (ultimaTecla == teclaSelecionada) {
                    tempoAtual = 0;
                    RandomTeclas();
                }
                tempoAtual = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            if (teclaSelecionada == "direita") {
                RandomTeclas(); ptn++;
                if (ultimaTecla == teclaSelecionada) {
                    tempoAtual = 0;
                    RandomTeclas();
                }
                tempoAtual = 0;
            }
            else {
                RandomTeclas(); erros++;
                if (ultimaTecla == teclaSelecionada) {
                    tempoAtual = 0;
                    RandomTeclas();
                }
                tempoAtual = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            if (teclaSelecionada == "baixo") {
                RandomTeclas(); ptn++;
                if (ultimaTecla == teclaSelecionada) {
                    tempoAtual = 0;
                    RandomTeclas();
                }
                tempoAtual = 0;
            }
            else {
                RandomTeclas(); erros++;
                if (ultimaTecla == teclaSelecionada) {
                    tempoAtual = 0;
                    RandomTeclas();
                }
                tempoAtual = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            if (teclaSelecionada == "esquerda") {
                RandomTeclas(); ptn++;
                if (ultimaTecla == teclaSelecionada) {
                    tempoAtual = 0;
                    RandomTeclas();
                }
                tempoAtual = 0;
            }
            else {
                RandomTeclas(); erros++;
                if (ultimaTecla == teclaSelecionada) {
                    tempoAtual = 0;
                    RandomTeclas();
                }
                tempoAtual = 0;
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
