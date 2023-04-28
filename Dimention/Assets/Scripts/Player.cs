using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    bool isCrouched = false;
    FirstPersonController fpc;
    public bool hasSword = false;
    public List<string> inventory = new List<string>();
    public GameObject interText;
    public bool inRange = false;
    void Start()
    {
        sword.SetActive(true);
        anim = GetComponentInChildren<Animation>();
        fpc = GetComponent<FirstPersonController>();
        sword.SetActive(hasSword ? true : false);
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
        interText.SetActive(false);
        inRange = false;
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        if (Physics.Raycast(ray, out hit, 6))
        {
            if (hit.collider.gameObject.tag == "Interactable")
            {
                interText.SetActive(true);
                hit.collider.GetComponent<Interactable>().inRange = true;
                inRange = true;

            }
        }
        if (Input.GetMouseButtonDown(1) && hitDelay < 0)
        {
            if (Physics.Raycast(ray, out hit, 20))
            {
                if (hit.collider.gameObject.layer == 9)
                {
                    hit.collider.gameObject.GetComponent<Enemy>().takeDamage(15);
                }
            }
            hitDelay = 1;
        }
        // var bulletInstance = Instantiate(bullet, transform.position, Quaternion.identity);
        //bulletInstance.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * bulletSpeed;
        // bulletInstance.transform.Translate(Vector3.up);
        // Destroy(bulletInstance, 2);
        if (hitLength > 0)
        {
            swordHitbox.gameObject.SetActive(true);
        }
        else
        {
            swordHitbox.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            transform.localScale *= 0.5f;
            fpc.canSprint = false;
            fpc.canJump = false;
            isCrouched = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            transform.localScale *= 2;
            fpc.canSprint = true;
            fpc.canJump = true;
            isCrouched = false;
        }
    }
}
