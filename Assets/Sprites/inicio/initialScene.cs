using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class initialScene : MonoBehaviour
{
    public float position = 13.5f;
    public  GameObject tela;
    public GameObject text;
    public GameObject menuBox, boxCredits,logo;
    

    void Awake()
    {
        //boxCredits.SetActive(false);
        //menuBox.SetActive(false);

    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.Return))
        {
            menuBox.SetActive(true);
            logo.SetActive(false);
            
        }
    }
    public void loadMain () {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

   

    public void Tomenu()
    {
        boxCredits.SetActive(false);
        logo.SetActive(false);
        menuBox.SetActive(true);
    }

    public void Tocredits()
    {

        menuBox.SetActive(false);
        boxCredits.SetActive(true);
        logo.SetActive(false);
        

    }
}
