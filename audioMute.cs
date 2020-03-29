using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioMute : MonoBehaviour
{
    private bool toggle =false;
    public GameObject music,mute;
    public void ToggleSound()
     {
 
         if (toggle)
         {
             AudioListener.volume = 1f;
             mute.SetActive(true);
             music.SetActive(false);
             toggle = false;
         }
 
         else
         {
             AudioListener.volume = 0f;
             mute.SetActive(false);
             music.SetActive(true);
             toggle = true;
         }

     }
}
