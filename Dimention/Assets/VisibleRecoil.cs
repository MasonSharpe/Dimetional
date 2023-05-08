using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;
public class visiblerecoil : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem magicFlare;
    public Animator animator;
    public AudioClip shootSound;
    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
     if (Input.GetMouseButtonDown(1))
        {
            GetComponent<AudioSource>().PlayOneShot(shootSound);
            magicFlare.Play();
            CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);
        }   
    }
    
}
