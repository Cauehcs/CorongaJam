﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogOpening : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index, controller;
    public float typingSpeed;
    public GameObject continueButton;
    
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
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void nextSentence(){
        continueButton.SetActive(false);
        if(index< sentences.Length - 1){
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else{textDisplay.text = ""; continueButton.SetActive(false);}
    }

    public void toGame(){
        controller++;
        if(controller >= 9)
        {
            SceneManager.LoadScene("Cauê");
        }
    }
}
