using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseController : MonoBehaviour
{
    public  bool  Paused =false;
    public bool muted = false;
    public GameObject pauseMenuUi;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(Paused)
            {
               Resume();
            }
            else
            {
               Pause();
            }
        }
    }
   
    public void Resume()
    {
      pauseMenuUi.SetActive(false);
      Time.timeScale = 1f;
      Paused = false;
    }

    public void Pause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
            
    }

    public void exit()
    {
        SceneManager.LoadScene(0);
        pauseMenuUi.SetActive(false);
    }
}
