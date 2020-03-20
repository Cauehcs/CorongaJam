using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnVirus : MonoBehaviour
{
    public GameObject Virus;
    void Start()
    {
        InvokeRepeating("Spawn", 2f, 3f) ;
    }

    void Update()
    {
        
    }


    void Spawn()
    {
        Vector3 virusPos = new Vector3(Random.Range(-7, 7), transform.position.y);
        Instantiate(Virus, virusPos, Quaternion.identity);
    }
}
