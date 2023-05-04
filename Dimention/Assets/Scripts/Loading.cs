using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    float timer = 0;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1)
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
}
