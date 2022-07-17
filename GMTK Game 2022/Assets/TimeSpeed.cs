using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSpeed : MonoBehaviour
{

    float slowMoDuration;

    float counter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale != 1f)
            counter += Time.deltaTime;

        if(counter > slowMoDuration){
            Time.timeScale = 1f;
            counter = 0f;
        }
    }

    public void quickSlowMo(){
        slowMo(0.4f, .8f);
    }

    public void slowMo(float amount, float duration){
        Time.timeScale = amount;
        slowMoDuration = duration * amount;
        counter = 0f;
    }
}
