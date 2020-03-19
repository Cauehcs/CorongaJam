using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barsBerraviour : MonoBehaviour
{
    [SerializeField] Image[] bars;
    static float valorTedio, valorSaude, valorMedo;

    private void Update() {
        
        valorSaude = Mathf.Clamp(valorSaude, 0, 1);
        valorTedio = Mathf.Clamp(valorTedio, 0, 1);
        valorMedo = Mathf.Clamp(valorMedo, 0, 1);

        for (int i = 0; i < bars.Length; i++) {
            if (bars[i].fillAmount < 0.2) bars[i].color = Color.red;
            else if (bars[i].fillAmount < 0.5) bars[i].color = Color.yellow;
            else if (bars[i].fillAmount <= 1) bars[i].color = Color.green;
        }

        bars[0].fillAmount = valorTedio;
        bars[1].fillAmount = valorSaude;
        bars[2].fillAmount = valorMedo;
    }

    public static void ResetBars(float barra) {
        switch (barra) {
            case 0:
                valorTedio = 1;
                break;
            case 1:
                valorSaude = 1;
                break;
            case 2:
                valorMedo = 1;
                break;
            case 3:
                valorMedo = 1; valorSaude = 1; valorTedio = 1;
                break;
        }
    }

    public static void PerderBarra(float barra, float valor) {
        //0.0001
        switch (barra) {
            case 0: valorTedio -= valor;
                break;
            case 1: valorSaude -= valor;
                break;
            case 2: valorMedo -= valor;
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
            case 2:
                valorMedo += valor;
                break;
        }
    }

}
