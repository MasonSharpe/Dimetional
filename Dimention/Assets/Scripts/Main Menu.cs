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
    void Start()
    {
        prestigeMenu.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        prestigeText.text = "You have: " + gameManager.saveData.prestigePoints.ToString() + " Prestige Points.";
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Cutscene");
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
                    gameManager.saveData.swordLevel = Mathf.Clamp(gameManager.saveData.swordLevel++, 20, 0); break;
                case 2:
                    gameManager.saveData.gunLevel = Mathf.Clamp(gameManager.saveData.gunLevel++, 20, 0); break;
                case 3:
                    gameManager.saveData.movementLevel = Mathf.Clamp(gameManager.saveData.movementLevel++, 20, 0); break;
            }
            gameManager.saveData.prestigePoints--;
        }
    }
}
