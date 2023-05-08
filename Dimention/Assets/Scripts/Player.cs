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
    public int comboIndex = 0;
    float comboTimer;
    public GameObject bullet;
    float bulletSpeed = 40;
    public GameObject sword;
    Animation anim;
    public float health = 100;
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
    public int skillPoints = 0;
    bool[] info;
    public GameManager manager;
    public DeathScreen deathScreen;
    void Start()
    {
        manager = GameManager.thisObject.GetComponent<GameManager>();
        deathScreen.gameObject.SetActive(false);
        info = skillTree.upgradesGotten;
        sword.SetActive(true);
        hasSword = level == 1 ? false : true;
        anim = GetComponentInChildren<Animation>();
        fpc = GetComponent<FirstPersonController>();
        sword.SetActive(hasSword ? true : false);
        swordHitbox.gameObject.transform.localScale *= info[4] ? 1.5f : 1;
        GetComponent<StarterAssetsInputs>().cursorLocked = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        hitLength -= Time.deltaTime;
        hitDelay -= Time.deltaTime;
        comboTimer -= Time.deltaTime;
        energy += Time.deltaTime * 30;
        if (Input.GetMouseButtonDown(0) && hitDelay < 0 && energy != 0 && hasSword)
        {
            energy = Mathf.Clamp(energy - 45, 0, 100);
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
            if (hit.collider.gameObject.tag == "Interactable" && hit.collider.GetComponent<Interactable>().interactable)
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
                hit.collider.gameObject.GetComponentInParent<Enemy>().takeDamage(info[8] ? 25 : 15 * (manager.saveData.gunLevel * 0.05f + 1));
                 comboIndex += 1;
                 comboTimer = 1.3f;
                if (comboIndex == 2)
                {
                    hit.collider.gameObject.GetComponentInParent<Enemy>().takeDamage(info[8] ? 45 : 30 * (info[9] ? 1.35f : 1));
                    comboIndex = -1;
                }
            }
            else
            {
                 var bulletInstance = Instantiate(bullet, transform.position, Quaternion.identity);
                 bulletInstance.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * bulletSpeed;
                 bulletInstance.transform.Translate(new Vector3(0, 1, 0) * 2.7f);
                 Destroy(bulletInstance, 2);
            }
            hitDelay = info[7] ? 0.7f : 1;
            energy = Mathf.Clamp(energy - 10, 0, 100);
        }
        if (hitLength < (info[0] ? 0.8f : 0.6f) && hitLength > 0.2f)
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

    public void takeDamage(float damage)
    {
        damage *= info[5] && hitLength > 0.2f ? 1.5f : 1;
        health -= damage;
        if (health < 0)
        {
            deathScreen.gameObject.SetActive(true);
            GetComponent<StarterAssetsInputs>().cursorLocked = false;
            Cursor.lockState = CursorLockMode.None;
            deathScreen.OnDeath();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            takeDamage(other.gameObject.GetComponentInParent<Enemy>().damage);
        }

    }
}
