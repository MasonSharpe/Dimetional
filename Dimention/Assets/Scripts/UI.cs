using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Player player;
    public Slider health;
    public GameObject panel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        health.value = player.health;
        // Vector2 mousePos = Input.mousePosition;
        //Vector2 mouseDir = new Vector2(mousePos.x / Screen.width, mousePos.y / Screen.height);
        //print(panel.transform.position);
        //panel.transform.position = new Vector3(146, 65, 0) + (Vector3)mouseDir * 10;
    }
}
