using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public InputMaster inputMaster;
    public GameObject projectile;

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

        inputMaster.Player.Shoot.performed += ctx => Shoot();

        inputMaster.Enable();
    }
    

    private void OnDisable() {
        inputMaster.Disable();
    }

    void Shoot() {
        Debug.Log("Shoot");
        GameObject projectileInstance = Instantiate(projectile, transform.position, transform.rotation);
        
    }
}
