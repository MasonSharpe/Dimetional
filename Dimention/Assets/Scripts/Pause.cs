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
        else if (player.level == 5)
        {
            objective.text = "Defeat the Master Stapler and his minions and escape the facility!";
        }
        else
        {
            objective.text = "Kill half the enemies in a room and find the door to proceed!";
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
