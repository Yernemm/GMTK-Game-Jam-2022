using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{

    public GameObject projectile;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("ShootLoop");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ShootLoop(){
        while(true){
            yield return new WaitForSeconds(1f);
            Shoot();
        }
    }

    void Shoot(){
        Debug.Log("Shoot");
        GameObject projectileInstance = Instantiate(projectile, transform.position, transform.rotation);
    }
}
