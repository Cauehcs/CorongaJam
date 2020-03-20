using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barsBerraviour : MonoBehaviour
{
    [SerializeField] Sprite[] numbers, icons;
    [SerializeField] Image[] numbersPosition, iconPosition;

    static float valorTedio, valorSaude;
    string valorTedioText, valorSaudeText;

    private void Update() {
        //1 - Saúde 2 - Tédio

        valorTedioText = valorTedio.ToString();
        valorSaudeText = valorSaude.ToString();

        if (valorTedio < 20) {
            iconPosition[0].sprite = icons[2]; 
            numbersPosition[0].color = Color.red; numbersPosition[1].color = Color.red; numbersPosition[2].color = Color.red;
        } else if (valorTedio < 50) {
            iconPosition[0].sprite = icons[1];
            numbersPosition[0].color = Color.yellow; numbersPosition[1].color = Color.yellow; numbersPosition[2].color = Color.yellow;
        } else if (valorTedio <= 100) {
            iconPosition[0].sprite = icons[0];
            numbersPosition[0].color = Color.green; numbersPosition[1].color = Color.green; numbersPosition[2].color = Color.green;
        }

        if (valorSaude < 20) {
            iconPosition[1].sprite = icons[5];
            numbersPosition[3].color = Color.red; numbersPosition[4].color = Color.red; numbersPosition[5].color = Color.red;
        }
        else if (valorSaude < 50) {
            iconPosition[1].sprite = icons[4];
            numbersPosition[3].color = Color.yellow; numbersPosition[4].color = Color.yellow; numbersPosition[5].color = Color.yellow;
        }
        else if (valorSaude <= 100) {
            iconPosition[1].sprite = icons[3];
            numbersPosition[3].color = Color.green; numbersPosition[4].color = Color.green; numbersPosition[5].color = Color.green;
        }

    }


    public static void PerderBarra(float barra, float valor) {
        switch (barra) {
            case 0: valorTedio -= valor;
                break;
            case 1: valorSaude -= valor;
                break;
        }
    }

    public static void GanharBarra(float barra, float valor) {
        switch (barra) {
            case 0:
                valorTedio += valor;
                break;
            case 1:
                valorSaude += valor;
                break;
        }
    }

}
