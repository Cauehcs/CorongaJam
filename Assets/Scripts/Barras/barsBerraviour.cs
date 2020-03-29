using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class barsBerraviour : MonoBehaviour {
    [SerializeField] Sprite[] numbers, icons;
    [SerializeField] Image[] numbersPosition, iconPosition;

    public static bool transicaoBool;

    static float valorTedio, valorSaude;
    public string valorTedioText, valorSaudeText;

    public Animator animTarefa;
    [SerializeField] float decrescimoSegundosBarra;

    private void Start() {
        animTarefa.enabled = false;
        valorSaude = 101; valorTedio = 100;
        StartCoroutine(ContagemBarra(decrescimoSegundosBarra));
        StartCoroutine(timeA());
    }

    IEnumerator timeA() {
        yield return new WaitForSeconds(3);
        animTarefa.enabled = true;
    }

    private void Update() {
        SetUI(); Tarefa();
        SetColorUI();
        valorSaude = Mathf.Clamp(valorSaude, 0, 100);
        valorTedio = Mathf.Clamp(valorTedio, 0, 100);

        valorSaudeText = valorSaude.ToString();
        valorTedioText = valorTedio.ToString();

        if(valorSaude == 0) {
            SceneManager.LoadScene("Perdeu");  
        }
    }

    void Tarefa() {
        if (Input.GetKeyDown(KeyCode.Z)) {
            animTarefa.SetBool("pressionando", true);
        }
        
        if (Input.GetKeyUp(KeyCode.Z)) {
            animTarefa.SetBool("pressionando", false);
        }
        
    }

    void SetColorUI() {
        if (valorSaude >= 0 && valorSaude < 20) {
            iconPosition[0].sprite = icons[2];
            numbersPosition[6].color = Color.red;
            numbersPosition[0].color = Color.red; numbersPosition[1].color = Color.red; numbersPosition[2].color = Color.red;
        }
        else if (valorSaude >= 20 && valorSaude <= 50) {
            iconPosition[0].sprite = icons[1];
            numbersPosition[6].color = Color.yellow;
            numbersPosition[0].color = Color.yellow; numbersPosition[1].color = Color.yellow; numbersPosition[2].color = Color.yellow;
        }
        else if (valorSaude >= 51 && valorSaude <= 100) {
            iconPosition[0].sprite = icons[0];
            numbersPosition[6].color = Color.green;
            numbersPosition[0].color = Color.green; numbersPosition[1].color = Color.green; numbersPosition[2].color = Color.green;
        }

        if (valorTedio >= 0 && valorTedio < 50) {
            iconPosition[1].sprite = icons[5];
            numbersPosition[7].color = Color.red;
            numbersPosition[3].color = Color.red; numbersPosition[4].color = Color.red; numbersPosition[5].color = Color.red;
        }
        else if (valorTedio >= 50 && valorTedio <= 80) {
            iconPosition[1].sprite = icons[4];
            numbersPosition[7].color = Color.yellow;
            numbersPosition[3].color = Color.yellow; numbersPosition[4].color = Color.yellow; numbersPosition[5].color = Color.yellow;
        }
        else if (valorTedio >= 81 && valorTedio <= 100) {
            iconPosition[1].sprite = icons[3];
            numbersPosition[7].color = Color.green;
            numbersPosition[3].color = Color.green; numbersPosition[4].color = Color.green; numbersPosition[5].color = Color.green;
        }
    }



    void SetUI() {
        if (int.Parse(valorSaudeText) >= 100) {
            numbersPosition[0].enabled = true;
            numbersPosition[1].enabled = true;
            numbersPosition[0].sprite = numbers[1];
            numbersPosition[1].sprite = numbers[0];
            numbersPosition[2].sprite = numbers[0];
        }
        else if (int.Parse(valorSaudeText) > 9 && int.Parse(valorSaudeText) < 100) {
            numbersPosition[0].enabled = false;
            numbersPosition[1].enabled = true;
            numbersPosition[1].sprite = numbers[int.Parse(valorSaudeText.Substring(0, 1))];
            numbersPosition[2].sprite = numbers[int.Parse(valorSaudeText.Substring(valorSaudeText.Length - 1, 1))];
        }
        else if (int.Parse(valorSaudeText) < 10 && int.Parse(valorSaudeText) > 0) {
            numbersPosition[0].enabled = false;
            numbersPosition[1].enabled = false;
            numbersPosition[2].sprite = numbers[int.Parse(valorSaudeText.Substring(valorSaudeText.Length - 1, 1))];
        }
        else if (int.Parse(valorSaudeText) < 1) {
            numbersPosition[0].enabled = false;
            numbersPosition[1].enabled = false;
            numbersPosition[2].sprite = numbers[0];
        }

        if (int.Parse(valorTedioText) >= 100) {
            numbersPosition[3].enabled = true;
            numbersPosition[4].enabled = true;
            numbersPosition[3].sprite = numbers[1];
            numbersPosition[4].sprite = numbers[0];
            numbersPosition[5].sprite = numbers[0];
        }
        else if (int.Parse(valorTedioText) > 9 && int.Parse(valorTedioText) < 100) {
            numbersPosition[3].enabled = false;
            numbersPosition[4].enabled = true;
            numbersPosition[4].sprite = numbers[int.Parse(valorTedioText.Substring(0, 1))];
            numbersPosition[5].sprite = numbers[int.Parse(valorTedioText.Substring(valorTedioText.Length - 1, 1))];
        }
        else if (int.Parse(valorTedioText) < 10 && int.Parse(valorTedioText) > 0) {
            numbersPosition[3].enabled = false;
            numbersPosition[4].enabled = false;
            numbersPosition[5].sprite = numbers[int.Parse(valorTedioText.Substring(valorTedioText.Length - 1, 1))];
        }
        else if (int.Parse(valorTedioText) < 1) {
            numbersPosition[3].enabled = false;
            numbersPosition[4].enabled = false;
            numbersPosition[5].sprite = numbers[0];
        }
    }


    public static void PerderBarra(float barra, float valor) {
        switch (barra) {
            case 1:
                valorTedio -= valor;
                break;
            case 0:
                valorSaude -= valor;
                break;
        }
    }

    public static void GanharBarra(float barra, float valor) {
        switch (barra) {
            case 1:
                valorTedio += valor;
                break;
            case 0:
                valorSaude += valor;
                break;
        }
    }

    IEnumerator ContagemBarra(float tempoDescrescimo) {
        if (!barsBerraviour.transicaoBool) valorSaude--;
        if(valorTedio >= 20 ) yield return new WaitForSeconds(tempoDescrescimo);
        if (valorTedio < 19) yield return new WaitForSeconds(tempoDescrescimo / 5);
        StartCoroutine(ContagemBarra(decrescimoSegundosBarra));
    }

}
