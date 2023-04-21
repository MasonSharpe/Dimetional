using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkillTree : MonoBehaviour
{
    bool[] upgradesGotten = {true, false, false, false, false, false, false};
    int[] prerequisites = {0, 0, 1, 2, 3, 3, 4};
    string[] buttonNames = new string[7];
    void Start()
    {
       for (int i = 0; i < 7; i++)
        {
            buttonNames[i] = i.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Upgrade(GameObject self)
    {
        var index = buttonNames.ToList().IndexOf(self.name);
        print(index);
        if (upgradesGotten[prerequisites[index]])
        {
            self.SetActive(false);
            upgradesGotten[index] = true;
        }
    }
}
