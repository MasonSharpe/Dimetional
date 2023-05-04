using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int prestigePoints = 0;
    public int swordLevel = 1;
    public int gunLevel = 1;
    public int movementLevel = 1;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
