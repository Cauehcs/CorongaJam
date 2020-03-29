using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnVirus : MonoBehaviour
{
    public GameObject Virus;
    void Start()
    {
        InvokeRepeating("Spawn", 1.5f, 3f) ;
    }

    void Update()
    {
        
    }


    void Spawn()
    {
<<<<<<< HEAD
        if(EscolherGame.inInvaders == true){
        Vector3 virusPos = new Vector3(Random.Range(67.808f, 79.981f), transform.position.y);
=======
        Vector3 virusPos = new Vector3(Random.Range(-7, 7), this.transform.position.y);
>>>>>>> 36df497553540fba26c253559ea95dbb5bac6713
        Instantiate(Virus, virusPos, Quaternion.identity);
        }
    }
}
