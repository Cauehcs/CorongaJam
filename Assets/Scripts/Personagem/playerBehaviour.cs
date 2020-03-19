    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class playerBehaviour : MonoBehaviour
{
    [SerializeField] float speed;
    public Rigidbody2D my_Rb;

    private void Awake() {
        barsBerraviour.ResetBars(3);
    }

    private void FixedUpdate() {
    
        Movimentacao(speed);
       
        barsBerraviour.PerderBarra(0, 0.0001f * 4f);

        //0.0001f / 1.5f - ~5.0min 
        //0.0001f * 1.0f - ~3.15min
        //0.0001f * 2.0f - ~1.45min
        //0.0001f * 2.5f - ~1.15min

    }

    void Movimentacao(float speed) {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        my_Rb.velocity = new Vector2(horizontal * speed, vertical * speed);
    }
}
