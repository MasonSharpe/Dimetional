using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float elapsed = 0;
    public IEnumerator Shake (float duration, float magnitude)
    {
        print("g");
        //storing origional pos of camera
        Vector3 originalPos = transform.position;
        // keeping track of how much time has passed since start shake

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);
            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
