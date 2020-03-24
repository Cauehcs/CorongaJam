using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptGame : MonoBehaviour
{
    float segundos, minutos;
    public string tempoAtual;

    private void Start() {
        segundos = 0; minutos = 0;
        StartCoroutine(Cronometro());
    }

    private void Update() {
        if(segundos == 60) {
            segundos = 0;
            minutos++;
        }

        if(segundos < 10)tempoAtual = "0" + minutos + " : 0" + segundos;
        else tempoAtual = "0" + minutos + " : " + segundos;

        if (minutos == 5) print("Tempo acabou!");
    }

    IEnumerator Cronometro() {
        if (!barsBerraviour.transicaoBool)segundos++;
        yield return new WaitForSeconds(1);
        StartCoroutine(Cronometro());
    }
}
