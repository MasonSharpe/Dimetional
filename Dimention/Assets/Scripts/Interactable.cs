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
            print("h");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (type == 0)
            {
                player.inventory.Add(item);
                Destroy(gameObject);
            }
            else if (type == 1)
            {
                gameObject.layer = 7;
                ethereal = true;
                etherealPeriod = 0.5f;
                GetComponent<BoxCollider>().enabled = false;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            }
        }
    }
}
