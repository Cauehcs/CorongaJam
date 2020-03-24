using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchRoom : MonoBehaviour
{
    [SerializeField] Transform[] locaisTP;
    [SerializeField] Image transicao;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.name == "SalaQuarto") {
            StartCoroutine(TransicaoUp(0));
        }
        else if (collision.gameObject.name == "QuartoSala") {
            StartCoroutine(TransicaoUp(1));
        }
        else if (collision.gameObject.name == "QuartoBanheiro") {
            StartCoroutine(TransicaoUp(2));
        }
        else if (collision.gameObject.name == "BanheiroQuarto") {
            StartCoroutine(TransicaoUp(3));
        }

    }

    IEnumerator TransicaoUp(int caso) {
        barsBerraviour.transicaoBool = true;
        this.GetComponent<playerBehaviour>().enabled = false;
        this.GetComponent<Animator>().enabled = false;

        if (transicao.fillAmount < 1) {
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            transicao.fillAmount += 0.1f;
            yield return new WaitForSeconds(0.0001f);
            StartCoroutine(TransicaoUp(caso));
        }
        else {
            StartCoroutine(Teleport(caso));
            yield return new WaitForSeconds(0.8f);
            StartCoroutine(TransicaoDown());
        }
    }
    IEnumerator TransicaoDown() {
        if (transicao.fillAmount > 0) {
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            transicao.fillAmount -= 0.1f;
            yield return new WaitForSeconds(0.0001f);
            StartCoroutine(TransicaoDown());
        }
        else {
            this.GetComponent<playerBehaviour>().enabled = true;
            this.GetComponent<Animator>().enabled = true;   
            barsBerraviour.transicaoBool = false;
        }
    }



    IEnumerator Teleport(int caso) {
        switch (caso) {
            case 0: 
                yield return new WaitForSeconds(0);
                this.transform.position = locaisTP[2].position + new Vector3(2f, 0f, 0f);
                break;

            case 1: 
                yield return new WaitForSeconds(0);
                this.transform.position = locaisTP[4].position + new Vector3(-2f, 0f, 0f);
                break;

            case 2:
                yield return new WaitForSeconds(0);
                this.transform.position = locaisTP[1].position + new Vector3(0f, 2f, 0f);
                break;

            case 3:
                yield return new WaitForSeconds(0);
                this.transform.position = locaisTP[0].position + new Vector3(0f, -2f, 0f);
                break;

        }
    }
}
