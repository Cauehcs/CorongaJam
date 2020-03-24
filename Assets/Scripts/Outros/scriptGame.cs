using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptGame : MonoBehaviour
{
    static float diaAtual;
    bool passou, perdeu;

    float segundos, minutos;
    public string tempoAtual;
    [SerializeField] public float tempoMaximo;

    private void Awake() {
        passou = false; perdeu = false;
        segundos = 0; minutos = 0;
    }

    private void Start() {
        StartCoroutine(Cronometro());
    }

    private void FixedUpdate() {
        CronometroMethod();
    }

    void PassouFase() => passou = true;
    void PerdeuFase() => perdeu = true;

    void CronometroMethod() {
        if (segundos == 60) {
            segundos = 0;
            minutos++;
        }

        if (segundos < 10) tempoAtual = "0" + minutos + " : 0" + segundos;
        else tempoAtual = "0" + minutos + " : " + segundos;

        if (minutos == tempoMaximo) print("Tempo acabou!");
    }

    IEnumerator Cronometro() {
        if (!barsBerraviour.transicaoBool)segundos++;
        yield return new WaitForSeconds(1);
        StartCoroutine(Cronometro());
    }
}
