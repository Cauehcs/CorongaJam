using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioMute : MonoBehaviour
{
    private bool toggle;
    public GameObject mute,music;
    public void ToggleSound()
     {
         if (toggle)
         {
             AudioListener.volume = 1f;
             mute.SetActive(true);
             music.SetActive(false);
         }

 
         else
         {
             AudioListener.volume = 0f;
             mute.SetActive(false);
             music.SetActive(true);
         }

     }
}
