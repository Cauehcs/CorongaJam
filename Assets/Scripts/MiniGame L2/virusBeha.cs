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
        if (transform.position.y <= -8.59f)
        {
            GameController.lifeNave--;
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
