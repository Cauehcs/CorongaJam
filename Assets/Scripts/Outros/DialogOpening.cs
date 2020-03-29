using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class DialogOpening : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
     public TextMeshProUGUI textDisplay2;
    public string[] sentences;
    private int index, controller;
    public float typingSpeed;
    public GameObject continueButton;
    public GameObject cameraTransition;
    public GameObject imageReference;
    public GameObject txtReference;
    public GameObject txt2;
  

    void Start(){
        StartCoroutine(Type());
    }
    void Update(){
        if(textDisplay.text == sentences[index]){
            continueButton.SetActive(true);
        }
    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray()){
            textDisplay.text += letter;
            textDisplay2.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void nextSentence(){
        continueButton.SetActive(false);
        if(index >= 8){
            cameraTransition.transform.position = new Vector3(50, 0, -10);
            imageReference.transform.position = new Vector3(50, 0, -5555);
            txtReference.transform.position = new Vector3(183, 50, 1000000000);
            txt2.transform.position = new Vector3(183, 50, 0); 
            continueButton.transform.position = new Vector3(605, 35, 0);
            }
            
        if(index< sentences.Length - 1){
            index++;
            textDisplay.text = "";
            textDisplay2.text = "";
            StartCoroutine(Type());
            
        
        }
        
        else{textDisplay.text = ""; textDisplay2.text = ""; continueButton.SetActive(false);}
    

        
    }

    public void toGame(){
        controller++;
        if(controller >= 9)
        {
            SceneManager.LoadScene("Tutorial");
        }
    }
}
