using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameManager gameManager;
    public Canvas prestigeMenu;
    public TextMeshProUGUI prestigeText;
    public TextMeshProUGUI timeText;
    void Start()
    {
        gameManager = GameManager.thisObject.GetComponent<GameManager>();
        prestigeMenu.enabled = false;
        timeText.text = "Best time: " + gameManager.saveData.bestTime.ToString() + " seconds";
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        prestigeText.text = "You have: " + gameManager.saveData.prestigePoints.ToString() + " Prestige Points.";
    }

    public void StartGame()
    {
        if (gameManager.saveData.hasPlayedOnce)
        {
            SceneManager.LoadScene("level 1");
        }
        else
        {
            SceneManager.LoadScene("Cutscene");
        }
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void PrestigeMenu()
    {
        prestigeMenu.enabled = !prestigeMenu.enabled;
    }

    public void ToggleAudio()
    {

    }

    public void Load()
    {
        gameManager.Loader();
    }

    public void UpgradeStat(int stat)
    {
        if (gameManager.saveData.prestigePoints > 0)
        {
            switch (stat)
            {
                case 1:
                    gameManager.saveData.swordLevel = Mathf.Clamp(gameManager.saveData.swordLevel + 1, 0, 20); break;
                case 2:
                    gameManager.saveData.gunLevel = Mathf.Clamp(gameManager.saveData.gunLevel+ + 1, 0, 20); break;
                case 3:
                    gameManager.saveData.movementLevel = Mathf.Clamp(gameManager.saveData.movementLevel + 1, 0, 20); break;
            }
            gameManager.saveData.prestigePoints--;
        }
    }
}
