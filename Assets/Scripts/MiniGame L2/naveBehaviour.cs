using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class naveBehaviour : MonoBehaviour
{
    float hDirection;
    float vDirection;
    public float speed;
    public GameObject laser;
    public Vector3 laserpos;
    

    void Start()
    {
        
    }


    void Update()
    {
        if(EscolherGame.inInvaders == true) {
        Movimento();
        Shoot();
        }
    }


    void Movimento()
    {
        Transform posi = GetComponent<Transform>();
        //hDirection = Input.GetAxis("Horizontal");
        //transform.Translate(Vector3.right * speed * hDirection);
        vDirection = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.down * speed * vDirection);

        if (posi.position.x <= 82.71414f)
            {
                posi.position = new Vector3(82.71414f, posi.position.y, posi.position.z);
            }
            else if (posi.position.x >= 99.11f)
            {
                posi.position = new Vector3(99.11f, posi.position.y, posi.position.z);

            }
       
                
        
        
        /*if (posi.position.y <= -4 )
        {
            posi.position = new Vector3(posi.position.x, -4f, posi.position.z);
        }
        else if(posi.position.y >= 4) 
        { posi.position = new Vector3(posi.position.x, 4f, posi.position.z); }*/


        {
            //if (posi.position.x >= 14.18f || posi.position.x <= -14.18f)
            //{
            //    posi.position = new Vector3(posi.position.x * -1, posi.position.y, posi.position.z);
            //}

            //else if (posi.position.y >= 5.44f || posi.position.y <= -5.44f)
            //{
            //    posi.position = new Vector3(posi.position.x, posi.position.y * -1, posi.position.z);

            //}
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "asteroid")
        {            
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(laser, transform.position + laserpos, Quaternion.identity);
        }
    }
}
