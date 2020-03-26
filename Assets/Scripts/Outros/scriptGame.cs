using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scriptGame : MonoBehaviour {
    static float diaAtual;
    bool passou, perdeu;

    [SerializeField] float quantidadeSujeira, diaAtualA;
    
    public GameObject[] sujeiras, principais;
    float segundos, minutos;
    public string tempoAtual;
    [SerializeField] public float tempoMaximo;

    [SerializeField] Sprite[] numbers;
    public Image[] positions;

    private void Awake() {
        
        passou = false; perdeu = false;
        segundos = 0; minutos = tempoMaximo;
    }

    private void Start() {
        StartCoroutine(Cronometro());
        diaAtual = diaAtualA;
    }

    private void FixedUpdate() {
        AtividadesDia();
        CronometroMethod();
        ContadorUI();
    }

    float aux = 0;
    void AtividadesDia() {
        if(diaAtual == 1) {
            principais[0].SetActive(true);
            principais[1].SetActive(false);
        }
        else if(diaAtual == 2) {
            principais[1].SetActive(true);
            principais[0].SetActive(false);
        }
        else if(diaAtual == 3) {
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
