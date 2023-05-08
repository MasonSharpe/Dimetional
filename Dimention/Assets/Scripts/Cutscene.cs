using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    public TextMeshProUGUI text;
    public string[] lines = {"once upon a time, stufff", "this is the next line. more lore. awesome!"};
    string currentLine = "";
    int lineIndex = 0;
    int charIndex = 0;
    float moveTimer = 0;
    void Start()
    {
        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        moveTimer += Time.deltaTime;
        if (text.text.Length < lines[lineIndex].Length)
        {
            text.text = currentLine + lines[lineIndex][charIndex];
            currentLine = text.text;
            charIndex++;
        }
        if (moveTimer > 5)
        {
            if (lineIndex > lines.Length - 2)
            {
                SceneManager.LoadScene("level 1");
            }
            lineIndex++;
            charIndex = 0;
            moveTimer = 0;
            currentLine = "";
            text.text = "";
        }
    }
}
