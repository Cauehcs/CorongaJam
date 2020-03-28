using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class virusBeha : MonoBehaviour
{
    public float speed;
    void Start()
    {

    }


    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if (transform.position.y <= -5.5f)
        {
            GameController.lifeNave--;
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "laser")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
