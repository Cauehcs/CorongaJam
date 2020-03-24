using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickTimeGenerator : MonoBehaviour
{
    [SerializeField] string[] teclasQuickTime;
    [SerializeField] string teclaSelecionada, ultimaTecla;

    public float tempoTrocaTecla;
    float tempoAtual;

    private void Start() {
        tempoAtual = tempoTrocaTecla;
    }

    private void Update() {
        if(tempoAtual >= tempoTrocaTecla) {
            ultimaTecla = teclaSelecionada;
            tempoAtual = 0; RandomTeclas();
            if (ultimaTecla == teclaSelecionada) {
                print("1");
                RandomTeclas();
            }
        }
        else {
            tempoAtual += Time.deltaTime;
        }
    }

    void RandomTeclas() {
        teclaSelecionada = teclasQuickTime[Random.Range(0, teclasQuickTime.Length)];
    }
}
