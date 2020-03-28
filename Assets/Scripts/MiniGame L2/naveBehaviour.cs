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
        Movimento();
        Shoot();
    }


    void Movimento()
    {
        Transform posi = GetComponent<Transform>();
        hDirection = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.down* speed * hDirection);
        //vDirection = Input.GetAxis("Vertical");
        //transform.Translate(Vector3.up * speed * vDirection);

        if (posi.position.x >= 8f)
            {
                posi.position = new Vector3(8f, posi.position.y, posi.position.z);
            }
            else if (posi.position.x <= -8f)
            {
                posi.position = new Vector3(-8f, posi.position.y, posi.position.z);
            }
       
                
        
        
        if (posi.position.y <= -4 )
        {
            posi.position = new Vector3(posi.position.x, -4f, posi.position.z);
        }
        else if(posi.position.y >= 4) 
        { posi.position = new Vector3(posi.position.x, 4f, posi.position.z); }


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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject)
        {
            
            Destroy(collision.gameObject);
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
