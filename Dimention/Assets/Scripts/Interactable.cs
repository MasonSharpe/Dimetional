using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Player player;
    public string item = "NA";
    float etherealPeriod = 0;
    bool ethereal = false;
    public int type = 0;
    public GameObject sceneObject;
    public bool inRange = false;
    public bool interactable = true;
    public bool isEnd = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        etherealPeriod -= Time.deltaTime;
        if (etherealPeriod < 0 && ethereal)
        {
            GetComponent<BoxCollider>().enabled = true;
            ethereal = false;
        }
        if (Input.GetKeyDown(KeyCode.E) && (inRange && player.inRange))
        {
                switch (type)
                {
                    case 0:
                        player.inventory.Add(item);
                        Destroy(gameObject); break;
                    case 1:
                        if (player.hasSword)
                        {
                            gameObject.layer = 7;
                            ethereal = true;
                            etherealPeriod = 0.5f;
                            GetComponent<BoxCollider>().enabled = false;
                            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                        }
                        break;
                    case 3:
                        if (player.inventory.Contains(item))
                        {
                            player.inventory.Remove(item);
                        Destroy(gameObject);
                    }
                        break;
                    case 4:
                        break;
                    case 5:
                        sceneObject.gameObject.SetActive(true);
                        player.hasSword = true;
                        Destroy(gameObject); break;
                    case 6:
                    player.skillPoints++;
                    Destroy(gameObject); break;
                    case 7:
                    player.health += 50;
                    Destroy(gameObject);  break;
                }
            if (isEnd)
            {
                if (player.enemiesKilled >= player.enemiesInRoom / 2)
                {
                    sceneObject.gameObject.GetComponent<UI>().openMenu();

                }
            }
        }
        inRange = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (type == 4)
        {
            sceneObject.gameObject.GetComponent<UI>().openMenu();
        }
    }
}
