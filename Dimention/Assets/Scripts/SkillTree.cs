using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillTree : MonoBehaviour
{
    bool[] upgradesGotten = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
    public GameObject player;
    public TextMeshProUGUI text;
    string[] descriptions = {
        "Increase Sword attack speed.",
        "Increase Sword damage.",
        "The Sword deals much more damage on the first hit on an enemy.",
        "All Sword Combo moves deal more damage.",
        "Sword hitbox is much much bigger.",
        "Take more damage when swinging your sword, but deal much more damage.",
        "Hold down the attack button on the last hit of a combo to do a Cyclone Slash that has a wide attack range.",
        "Increase Gun attack speed.",
        "Increase Gun damage.",
        "All Gun Combo moves deal more damage.",
        "Increase Gun attack speed at low health.",
        "Bullets do more damage the more times you've shot an enemy.",
        "The Gun's attack rate is greatly increased, but damage is decreased.",
        "Hold down the shoot button on the last hit of a combo to do a Burst Fire that fire multiple bullets in very quick succession.",
        "Increase Movement speed.",
        "Increase Stamina efficiency.", 
        "Deal much more damage while Sneaking.",
        "Gain a chance to not take damage on hit.",
        "Greatly increase Sneak and Walking speed, but you can no longer run.", 
        "Reduce damage taken by 5.", 
        "Gain an invincible dash that covers a great distance (use with Shift key).", 
         //group 1 : firsthit, swordbox, || takewhenswinging, combodamage
         //group 2 : moreonshot, combodamage || gunbox, attackratereduced
         //group 3: sneakdamage, runless || chancenodamage, damagereduce
    };
    void Start()
    {
        EventTrigger trigger = GetComponent<EventTrigger>();
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
            applyUpgrade(info.buttonIndex);
            self.SetActive(false);
            upgradesGotten[info.buttonIndex] = true;
        }
    }

    public void applyUpgrade(int index)
    {
        switch (index)
        {
            case 0:
                player.GetComponent<FirstPersonController>().MoveSpeed += 20;
                break;
        }
    }

    public void nextLevel()
    {

    }

    public void updateDescription(int index)
    {
        text.text = descriptions[index];
    }
}
