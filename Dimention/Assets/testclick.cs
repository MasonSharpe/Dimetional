using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using EZCameraShake;
public class testclick : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem magicFlare;
    public Animator animator;
    public Animation BasicMagicSlash;
    public static AudioClip blastSound;
    public static AudioClip fireSound;
    static AudioSource audioSrc;
    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
     if (Input.GetMouseButtonDown(0))
        {
            testclick.PlaySound("blastSound");
            magicFlare.Play();
            //CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);
        }   
    }
    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "fire":
                audioSrc.PlayOneShot(blastSound); break;
                
        }
    }
}
