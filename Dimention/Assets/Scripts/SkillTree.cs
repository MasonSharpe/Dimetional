using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkillTree : MonoBehaviour
{
    bool[] upgradesGotten;
    int[] prerequisites = {0, 1, 2, 3, 3, 4};
    string[] buttonNames = {"a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a"};
    void Start()
    {
       // for (int i = 0; i < 10; i++)
      //  {
         //   buttonNames.Append("i");
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Upgrade(GameObject self)
    {
        print(buttonNames.Length);
        print(buttonNames[2]);
        //var index = buttonNames.ToList().IndexOf(self.name);
        
       // if (upgradesGotten[prerequisites[index]])
       // {
       //     self.SetActive(false);
       // }
    }
}
