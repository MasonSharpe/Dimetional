using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkillTree : MonoBehaviour
{
    bool[] upgradesGotten = {false, false, false, false, false, false};
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Upgrade(GameObject self)
    {
        Button info = self.GetComponent<Button>();
        bool canUpgrade = true;
        if (info.prerequisites[0] == -1)
        {
            canUpgrade = true;
        }
        else
        {
            for (int i = 0; i < info.prerequisites.ToArray().Length; i++)
            {
                if (!upgradesGotten[info.prerequisites[i]])
                {
                    canUpgrade = false;
                }
            }
        }
        if (canUpgrade)
        {
            self.SetActive(false);
            upgradesGotten[info.buttonIndex] = true;
        }
    }
}
