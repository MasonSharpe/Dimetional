using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    bool open = false;
    Canvas canvas;
    public Player player;
    public TextMeshProUGUI prestige;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        prestige.text = "+" + player.level + " Prestige Points! Spend them in the Main Menu!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnDeath()
    {
        Time.timeScale = 0;
        canvas.enabled = true;
        open = true;
        player.gameObject.GetComponent<StarterAssetsInputs>().cursorLocked = false;
        Cursor.lockState = CursorLockMode.None;
    }
}