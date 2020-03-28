using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; 
using UnityEngine.SceneManagement;

public class snakeMovement : MonoBehaviour
{
    public Sprite[] snakePosition;
    public Vector2 dir = Vector2.right;
    bool ate = false;
    List<Transform> tail = new List<Transform>();
    
   
    public GameObject tailPrefab;
    void Start () {
        InvokeRepeating("move", 0.3f, 0.3f);    
    }
   
    void Rotation() {
        if(dir.x == 1) {
            GetComponent<SpriteRenderer>().sprite = snakePosition[0];
        }
        else if (dir.x == -1) {
            GetComponent<SpriteRenderer>().sprite = snakePosition[2];
        }
        else if (dir.y == -1) {
            GetComponent<SpriteRenderer>().sprite = snakePosition[1];
        }
        else if (dir.y == 1) {
            GetComponent<SpriteRenderer>().sprite = snakePosition[3];
        }
    }
    
    void Update () {

        Rotation();

    if (Input.GetKeyDown(KeyCode.RightArrow)&& dir != -Vector2.right)
    {dir = Vector2.right;}
        
    if (Input.GetKeyDown(KeyCode.DownArrow) && dir != Vector2.up)
        {dir = -Vector2.up;}    
    if (Input.GetKeyDown(KeyCode.LeftArrow)&& dir != Vector2.right)
        {dir = -Vector2.right;} 
    if (Input.GetKeyDown(KeyCode.UpArrow)&& dir != -Vector2.up)
        {dir = Vector2.up;}
    }

    void move()
    {
        
    Vector2 v = transform.position;

    
    transform.Translate(dir);

    if (ate) {
        GameObject g =(GameObject)Instantiate(tailPrefab,v,Quaternion.identity);
 
        tail.Insert(0, g.transform);

        ate = false;
    }
    
    else if (tail.Count > 0) {
   
        tail.Last().position = v;

       
        tail.Insert(0, tail.Last());
        tail.RemoveAt(tail.Count-1);
    }
    }
    void OnTriggerEnter2D(Collider2D coll) {

      if (coll.gameObject.tag == "apple") 
        {
         ate = true;
          Destroy(coll.gameObject);
          spawnApple.appleAppear = false;
        }
   
    if(coll.gameObject.tag == "Player")
    {
         SceneManager.LoadScene("snakePedro");
         spawnApple.appleAppear = false;
    }
    if(coll.gameObject.tag == "Border")
    {
         SceneManager.LoadScene("snakePedro");
         spawnApple.appleAppear = false;
    }
}
}

    

