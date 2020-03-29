using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class scriptGame : MonoBehaviour {
    static float diaAtual;
    bool passou, perdeu;

    public GameObject[] txtTarefas;
    [SerializeField] float quantidadeSujeira;
    
    public GameObject[] sujeiras, principais;
    float segundos, minutos;
    public string tempoAtual;
    [SerializeField] float tempoMaximo;

    [SerializeField] Sprite[] numbers;
    public Image[] positions;
    public Text txtInicial;

    public static float proxFase;
    public bool a;
    private void Awake() {
        proxFase = 0;
        diaAtual = PlayerPrefs.GetFloat("dia");
        passou = false; perdeu = false;
        segundos = 0; minutos = tempoMaximo;
        txtInicial.text = "Dia: " + diaAtual.ToString();
    }

    public static void ProximaFase() {
        proxFase++;
    }

    private void Start() {
        StartCoroutine(Cronometro());
    }

    private void FixedUpdate() {
        AtividadesDia();
        CronometroMethod();
        ContadorUI();

        if (proxFase == 4) passou = true;

        if (passou && diaAtual == 3) {
            SceneManager.LoadScene("Ganhou");
            
        }

        if (a) passou = true;

        if (passou) {
            passou = false;
            diaAtual++;
            PlayerPrefs.SetFloat("dia", diaAtual);
            PlayerPrefs.Save();
            if(diaAtual > 3) {
                PlayerPrefs.SetFloat("dia", 1f);
                PlayerPrefs.Save();
            }
            else SceneManager.LoadScene("Cauê");
        }
        if (perdeu) {
            perdeu = false;
            PlayerPrefs.SetFloat("dia", diaAtual);
            SceneManager.LoadScene("Cauê");
            PlayerPrefs.Save();
        }
    }

    float aux = 0;
    void AtividadesDia() {
        if(diaAtual == 1) {
            tempoMaximo = 4;
            principais[0].SetActive(true);
            txtTarefas[0].SetActive(true);
            principais[1].SetActive(false);
        }
        else if(diaAtual == 2) {
            tempoMaximo = 3;
            principais[1].SetActive(true);
            txtTarefas[1].SetActive(true);
            principais[0].SetActive(false);
        }
        else if(diaAtual == 3) {
            tempoMaximo = 2;
            txtTarefas[2].SetActive(true);
            principais[0].SetActive(false);
            principais[1].SetActive(false);

            if (aux < quantidadeSujeira) {
                int sort = Random.Range(0, 7);
                sort = Mathf.Clamp(sort, 0, 6);
                if (!sujeiras[sort].activeSelf) {
                    aux++;
                    sujeiras[sort].SetActive(true);
                }
            }
        }
    }

    void ContadorUI() {
        positions[0].sprite = numbers[0];
        positions[1].sprite = numbers[(int)minutos];

        if (segundos < 10) positions[2].sprite = numbers[0];
        else positions[2].sprite = numbers[int.Parse(segundos.ToString().Substring(0,1))];

        if (segundos == 0) positions[3].sprite = numbers[0];
        else positions[3].sprite = numbers[int.Parse(segundos.ToString().Substring(segundos.ToString().Length - 1, 1))];
    }

    void PassouFase() => passou = true;
    void PerdeuFase() => perdeu = true;

    void CronometroMethod() {
        if (segundos < 0) {
            segundos = 59;
            minutos--;
        }

        if (segundos < 10) tempoAtual = "0" + minutos + " : 0" + segundos;
        else tempoAtual = "0" + minutos + " : " + segundos;

        if (minutos == 0 && segundos == 0) print("Tempo acabou!");
    }

    IEnumerator Cronometro() {
        yield return new WaitForSeconds(1);
        if (!barsBerraviour.transicaoBool) segundos--;
        StartCoroutine(Cronometro());
    }
}
