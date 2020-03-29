using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tutorialScript : MonoBehaviour
{
    float index;
    public GameObject[] cenas;

    private void Start() {
        index = 0;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.X)) {
            index++;
        }

        if(index == 0) {
            cenas[0].SetActive(true);
            cenas[1].SetActive(false);
            cenas[2].SetActive(false);
        }

        if (index == 1) {
            cenas[0].SetActive(false);
            cenas[1].SetActive(true);
            cenas[2].SetActive(false);
        }

        if (index == 2) {
            cenas[0].SetActive(false);
            cenas[1].SetActive(false);
            cenas[2].SetActive(true);
        }

        if(index == 3) {
            SceneManager.LoadScene("Cauê");
        }
    }
}
