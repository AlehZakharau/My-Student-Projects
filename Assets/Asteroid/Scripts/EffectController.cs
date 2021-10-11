using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    public float lifeTime = 1f;

    private float time;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        
        if(time > lifeTime)
            Destroy(gameObject);
    }
}
