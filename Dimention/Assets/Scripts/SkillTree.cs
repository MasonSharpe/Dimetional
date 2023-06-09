using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SkillTree : MonoBehaviour
{
    public bool[] upgradesGotten = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
    public GameObject player;
    public TextMeshProUGUI text;
    public TextMeshProUGUI pointsLeft;
    int points = 3;
    string[] descriptions = {// comments indicate which ones work
        "Increase Sword attack speed.", //
        "Increase Sword damage.",//
        "The Sword deals much more damage on the first hit on an enemy.",//
        "All Sword Combo moves deal more damage.",//
        "Sword hitbox is much much bigger.",//
        "Take more damage when swinging your sword, but deal much more damage.",//
        "Hold down the attack button on the last hit of a combo to do a Cyclone Slash that has a wide attack range.",
        "Increase Magic attack speed.",//
        "Increase Magic damage.",//
        "All Magic Combo moves deal more damage.",//
        "Increase Magic attack speed at low health.",//
        "Bullets do more damage the more times you've blasted an enemy.",//
        "Magic's attack rate is greatly increased, but damage is decreased.",//
        "Hold down the shoot button on the last hit of a combo to do a Burst Fire that fire multiple blasts in very quick succession.",
        "Increase Movement speed.",//
        "Increase Stamina efficiency.", //
        "Deal much more damage while Sneaking.",//
        "Gain a chance to not take damage on hit.",//
        "Greatly increase Sneak and Walking speed.", 
        "Reduce damage taken by 5.", //
        "Gain an invincible dash that covers a great distance (use with Shift key).", 
         //group 1 : firsthit, swordbox, || takewhenswinging, combodamage
         //group 2 : moreonshot, combodamage || gunbox, attackratereduced
         //group 3: sneakdamage, runless || chancenodamage, damagereduce
    };


    private void Awake()
    {
        upgradesGotten = GameManager.thisObject.GetComponent<GameManager>().upgradesGotten;
    }
    void Start()
    {
        points = player.GetComponent<Player>().skillPoints;
        pointsLeft.text = "Points left: " + points.ToString();
        Time.timeScale = 0;
        Button[] buttons = GetComponentsInChildren<Button>();
        for (int i = 0; i < upgradesGotten.Length; i++)
        {
            if (upgradesGotten[i])
            {
                for (int j = 0; j < buttons.Length; j++)
                {
                    if (buttons[j].buttonIndex == i)
                    {
                        buttons[j].gameObject.SetActive(false);
                    }
                }
            }
        }
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
        if (canUpgrade && points > 0)
        {
            applyUpgrade(info.buttonIndex);
            self.SetActive(false);
            upgradesGotten[info.buttonIndex] = true;
            points--;
            pointsLeft.text = "Points left: " + points.ToString();
        }
    }

    public void applyUpgrade(int index)
    {
            switch (index)
            {
            case 0:
                 break;
        }
    }

    public void nextLevel()
    {
        Time.timeScale = 1;
        player.GetComponent<StarterAssetsInputs>().cursorLocked = true;
        Cursor.lockState = CursorLockMode.Locked;
        GameManager.thisObject.GetComponent<GameManager>().upgradesGotten = upgradesGotten;
        if (player.GetComponent<Player>().level == 5)
        {
            player.gameObject.GetComponent<StarterAssetsInputs>().cursorLocked = false;
            Cursor.lockState = CursorLockMode.None;
        }
        SceneManager.LoadScene("level " + (player.GetComponent<Player>().level + 1).ToString());
    }

    public void updateDescription(int index)
    {
        text.text = descriptions[index];
    }
}
