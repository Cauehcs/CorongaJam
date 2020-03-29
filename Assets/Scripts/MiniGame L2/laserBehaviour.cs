using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserBehaviour : MonoBehaviour
{
    public float speed;

    void Start()
    {
        
    }

    
    void Update()
    {
        if(EscolherGame.inInvaders == true){
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        if(transform.position.y > 6) { Destroy(this.gameObject);
         }
         }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        Destroy(this.gameObject);
    }
}
