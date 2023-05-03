using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    bool open = false;
    public Player player;
    public TextMeshProUGUI objective;
    Canvas canvas;
    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
        if (player.level == 1)
        {
            objective.text = "Unlock the door to escape!";
        }
        else
        {
            objective.text = "Power up and find the exit by cutting through enemies!";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (open)
            {
                Resume();
            }
            else
            {
                Time.timeScale = 0;
                canvas.enabled = true;
                open = true;
                player.gameObject.GetComponent<StarterAssetsInputs>().cursorLocked = false;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
    public void Resume()
    {
        Time.timeScale = 1.0f;
        canvas.enabled = false;
        open = false;
        player.gameObject.GetComponent<StarterAssetsInputs>().cursorLocked = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void QuitToMain()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
