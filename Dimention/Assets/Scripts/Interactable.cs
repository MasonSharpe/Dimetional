using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Player player;
    public string item = "NA";
    public int type = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            }
        }
    }
}
