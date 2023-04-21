using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject swordHitbox;
    float hitLength = 0;
    float hitDelay = 0;
    int comboIndex = 0;
    public float swordDamage;
    float comboTimer;
    public GameObject bullet;
    float bulletSpeed = 5;
    public GameObject sword;
    Animation anim;
    public int health = 100;
    void Start()
    {
        anim = GetComponentInChildren<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        hitLength -= Time.deltaTime;
        hitDelay -= Time.deltaTime;
        comboTimer -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && hitDelay < 0)
        {
            swordHitbox.gameObject.transform.rotation = gameObject.transform.rotation;
            swordDamage = 10;
            if(comboTimer < 0)
            {
                comboIndex = 0;
            }
            if (comboIndex == 2)
            {
                swordHitbox.transform.Rotate(0, 0, 90);
                comboIndex = -1;
                swordDamage = 30;
                anim.Play("Swing Combo");
            }
            else
            {
                anim.Play("Sword Swing");
            }
            comboIndex += 1;
            hitLength = 0.5f;
            hitDelay = 1;
            comboTimer = 1.3f;
        }
        if (Input.GetMouseButtonDown(1) && hitDelay < 0)
        {
            var bulletInstance = Instantiate(bullet, transform.position, Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * bulletSpeed;
            bulletInstance.transform.Translate(Vector3.up);
            Destroy(bulletInstance, 2);
            hitDelay = 1;
        }
        if (hitLength > 0)
        {
            swordHitbox.gameObject.SetActive(true);
        }
        else
        {
            swordHitbox.gameObject.SetActive(false);
        }
    }
}
