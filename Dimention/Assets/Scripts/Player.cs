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
    float comboTimer;
    public GameObject bullet;
    float bulletSpeed = 40;
    public GameObject sword;
    Animation anim;
    public int health = 100;
    bool isCrouched = false;
    FirstPersonController fpc;
    public bool hasSword = false;
    public List<string> inventory = new List<string>();
    public GameObject interText;
    public bool inRange = false;
    public float energy = 100;
    public int enemiesInRoom = 0;
    public int enemiesKilled = 0;
    public int level = 0;
    public SkillTree skillTree;
    bool[] info;
    void Start()
    {
        sword.SetActive(true);
        anim = GetComponentInChildren<Animation>();
        fpc = GetComponent<FirstPersonController>();
        sword.SetActive(hasSword ? true : false);
        info = skillTree.upgradesGotten;
    }

    // Update is called once per frame
    void Update()
    {
        hitLength -= Time.deltaTime;
        hitDelay -= Time.deltaTime;
        comboTimer -= Time.deltaTime;
        energy += Time.deltaTime * 10;
        if (Input.GetMouseButtonDown(0) && hitDelay < 0 && energy != 0 && hasSword)
        {
            energy = Mathf.Clamp(energy - 25, 0, 100);
            swordHitbox.gameObject.transform.rotation = gameObject.transform.rotation;
            if(comboTimer < 0)
            {
                comboIndex = 0;
            }
            if (comboIndex == 2)
            {
                swordHitbox.transform.Rotate(0, 0, 90);
                comboIndex = -1;
                anim.Play("Swing Combo");
            }
            else
            {
                anim.Play("Sword Swing");
            }
            comboIndex += 1;
            hitLength = 1f;
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
        if (Input.GetMouseButtonDown(1) && hitDelay < 0 && hasSword)
        {
            if (Physics.Raycast(ray, out hit, 100) && hit.collider.gameObject.layer == 9)
            {
                 hit.collider.gameObject.GetComponent<Enemy>().takeDamage(15);
            }
            else
            {
                 var bulletInstance = Instantiate(bullet, transform.position, Quaternion.identity);
                 bulletInstance.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * bulletSpeed;
                 bulletInstance.transform.Translate(new Vector3(0, 1, 0) * 2.7f);
                 Destroy(bulletInstance, 2);
            }
            hitDelay = 1;
            energy = Mathf.Clamp(energy - 10, 0, 100);
        }
        if (hitLength < (info[0] ? 0.75f : 0.5f) && hitLength > 0.2f)
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
