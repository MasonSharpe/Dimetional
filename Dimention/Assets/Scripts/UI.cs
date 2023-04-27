using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject player;
    public Slider health;
    public GameObject panel;
    public GameObject skillTree;
    public bool isInMenu = false;
    void Start()
    {
        skillTree.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        health.value = player.GetComponent<Player>().health;
        // Vector2 mousePos = Input.mousePosition;
        //Vector2 mouseDir = new Vector2(mousePos.x / Screen.width, mousePos.y / Screen.height);
        //print(panel.transform.position);
        //panel.transform.position = new Vector3(146, 65, 0) + (Vector3)mouseDir * 10;
    }
    public void openMenu()
    {
        if (isInMenu)
        {
            player.GetComponent<StarterAssetsInputs>().cursorLocked = true;
            skillTree.SetActive(false);
            isInMenu = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
        }
        else
        {
            player.GetComponent<StarterAssetsInputs>().cursorLocked = false;
            skillTree.SetActive(true);
            isInMenu = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
    }
}
