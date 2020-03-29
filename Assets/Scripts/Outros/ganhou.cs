using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ganhou : MonoBehaviour
{
    private void Update() {
        if (Input.GetKeyDown(KeyCode.X)) {
            SceneManager.LoadScene(0);
        }
    }
}
