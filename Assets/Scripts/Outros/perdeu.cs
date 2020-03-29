using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class perdeu : MonoBehaviour {
    private void Update() {
        if (Input.GetKeyDown(KeyCode.X)) {
            SceneManager.LoadScene("Cauê");
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene(0);
        }
    }
}
