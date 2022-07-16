using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillMe : MonoBehaviour
{

    public float lifetime;
    float time;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > lifetime){
            Destroy(gameObject);
        }
    }
}
