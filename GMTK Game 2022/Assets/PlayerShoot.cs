using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public InputMaster inputMaster;
    public GameObject projectile;

    bool isShooting = false;

    //Shots per second
    float fireRate = 2f;

    float cooldown = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable() {
        inputMaster = new InputMaster();

        inputMaster.Player.Shoot.performed += ctx => isShooting = true;
        inputMaster.Player.Shoot.canceled += ctx => isShooting = false;

        inputMaster.Enable();
    }
    

    private void OnDisable() {
        inputMaster.Disable();
    }

    void Shoot() {
        Debug.Log("Shoot");
        GameObject projectileInstance = Instantiate(projectile, transform.position, transform.rotation);

    }

    private void FixedUpdate() {
        if(isShooting && cooldown <= 0f) {
            Shoot();
            cooldown = 1f / fireRate;
        }

        if(cooldown > 0) {
            cooldown -= Time.deltaTime;
        }
    }
}
