using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float health = 10;
    float maxHealth;
    public Player player;
    public Slider healthBar;
    bool[] info;
    public NavMeshAgent nav;
    void Start()
    {
        maxHealth = health;
        healthBar.maxValue = maxHealth;
        info = player.skillTree.upgradesGotten;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = health;
        GetComponent<NavMeshAgent>().destination = player.transform.position;
    }

    public void takeDamage(float damage)
    {
        health -= damage;
        if (health < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sword")
        {
            float damage = (info[1] ? 45 : 30) * (info[2] && health == maxHealth ? 1.2f : 1) * (info[3] && player.comboIndex == 0 ? 1.5f : 1);
            damage *= player.comboIndex == 0 ? 1.5f : 1;
            damage = Mathf.Pow(damage, info[5] ? 1.5f : 1);
            takeDamage(damage);
        }
    }
}
