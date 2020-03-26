using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MiniGameSecundario : MonoBehaviour
{
    public bool interagiu;
    public bool animBool;
    float aux;

    private void Update() {
        if (interagiu) {
            interagiu = false;
            if(aux == 0) {
                barsBerraviour.PerderBarra(1, 40);
                barsBerraviour.GanharBarra(0, 10);
                aux++;
            }
            animBool = true;
        }
        aux = 0;
        this.GetComponent<Animator>().SetBool("done", animBool);
    }
}
