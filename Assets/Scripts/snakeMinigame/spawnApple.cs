using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnApple : MonoBehaviour
{
     public GameObject foodPrefab;

   
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;

    public static bool appleAppear = false;

  
    void Start () {
       
        InvokeRepeating("Spawn", 3, 4);
    }

    
    void Spawn() {
        
        if(EscolherGame.inSnake == true){ 
            int x = (int)Random.Range(borderLeft.position.x,borderRight.position.x);

      
            int y = (int)Random.Range(borderBottom.position.y,borderTop.position.y);

    
            if (appleAppear == false)
            {
                Instantiate(foodPrefab,new Vector2(x, y), Quaternion.identity);
                appleAppear = true;
            }
        }
       
    }
}
