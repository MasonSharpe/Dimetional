using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    void PlayAndDestroy(ParticleSystem part)
    {
        part = GetComponent<ParticleSystem>();
        part.Play();
        Destroy(gameObject, part.main.duration);
    }
}
