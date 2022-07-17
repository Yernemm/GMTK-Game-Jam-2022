using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed = 2300f;
    public float turnSpeed = 5f;

    public GameObject explosion;

    public Transform target;

    public ProjectileType type;

    GameObject camAim;

    

    // Start is called before the first frame update
    void Start()
    {
        camAim = GameObject.Find("CamAim");
    }

    // Update is called once per frame
    void Update()
    {
        switch(type){
            case ProjectileType.Player:
                target = camAim.transform;
            break;
            case ProjectileType.Enemy:
                target = GameObject.Find("Player").transform;
            break;
        }

        Quaternion initRotation = transform.rotation;
        Quaternion lookAtPlayer = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(initRotation, lookAtPlayer, turnSpeed * Time.deltaTime);
    }

     void FixedUpdate()
    {
        Vector3 v = gameObject.GetComponent<Rigidbody>().velocity;
        gameObject.GetComponent<Rigidbody>().velocity =  new Vector3(v.x * 0.5f, v.y * 0.5f, v.z * 0.5f);
        gameObject.GetComponent<Rigidbody>().velocity += transform.TransformDirection(new Vector3(0,0, speed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other) {
        if(type == ProjectileType.Player && !other.gameObject.CompareTag("Player") || type == ProjectileType.Enemy){
            Debug.Log(other);
            GameObject newExplosion = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(newExplosion, 25f);
            Destroy(gameObject);
        }
        
    }
}

public enum ProjectileType {
    Player,
    Enemy
}
