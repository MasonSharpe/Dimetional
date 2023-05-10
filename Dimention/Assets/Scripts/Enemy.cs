using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float health = 10;
    public float damage = 25;
    float maxHealth;
    public Player player;
    public Slider healthBar;
    bool[] info;
    public NavMeshAgent nav;
    public int timesShot = 0;
    void Start()
    {
        maxHealth = health;
        healthBar.maxValue = maxHealth;
        info = player.info;
        nav.isStopped = true;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = health;
        nav.destination = player.transform.position;
        if (Vector3.Distance(player.transform.position, transform.position) < 100 && nav.isStopped)
        {
            nav.isStopped = false;
        }
        else if(Vector3.Distance(player.transform.position, transform.position) > 100)
        {
            nav.isStopped = true;
        }
    }

    public void takeDamage(float damage)
    {
        health -= damage;
        if (health < 0)
        {
            player.enemiesKilled++;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sword")
        {
            float damage = (info[1] ? 45 : 30) * (info[2] && health == maxHealth ? 1.2f : 1) * (info[3] && player.comboIndex == 0 ? 1.5f : 1) * (player.manager.saveData.swordLevel * 0.05f + 1) * (info[16] && player.isCrouched ? 1.4f : 1);
            damage *= player.comboIndex == 0 ? 1.5f : 1;
            damage = Mathf.Pow(damage, info[5] ? 1.5f : 1);
            takeDamage(damage);
        }
    }
}
