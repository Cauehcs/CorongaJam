using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MiniGameSecundario : MonoBehaviour
{
    public enum MyEnum {
        bom, ruim
    }
    public GameObject[] listras;
    public MyEnum bomRuim;
    public bool interagiu;
    public bool animBool, eletronico, naoEletronico;
    float aux;


    private void Update() {
        if(bomRuim.ToString() == "ruim")
        if (interagiu) {
                
                if (this.gameObject.name == "LavarPrato") {
                    listras[3].SetActive(true);
                    listras[4].SetActive(true);
                }

                if (this.gameObject.name == "TomarBanho") {
                    listras[0].SetActive(true);
                }

                if (this.gameObject.name == "LavarMão") {
                    listras[1].SetActive(true);
                    listras[2].SetActive(true);
                }

                interagiu = false;
            if(aux == 0) {
                barsBerraviour.PerderBarra(1, 50);
                barsBerraviour.GanharBarra(0, 10);
                aux++;
            }
            animBool = true;
        }
       
        if (bomRuim.ToString() == "bom")
                if (interagiu) {
                    interagiu = false;
                    if (aux == 0) {
                        if (eletronico) {
                            barsBerraviour.GanharBarra(1, 35);
                            aux++;
                        }
                        if (naoEletronico) {
                            barsBerraviour.GanharBarra(1, 15);
                            aux++;
                        }
                }
                    animBool = true;
                }
        aux = 0;
        this.GetComponent<Animator>().SetBool("done", animBool);

        
    }
}
