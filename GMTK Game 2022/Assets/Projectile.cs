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

    public int diceValue = -1;

    GameObject camAim;

    GameObject player;

    

    // Start is called before the first frame update
    void Start()
    {
        camAim = GameObject.Find("CamAim");
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {


        if(type == ProjectileType.Player){
            target = camAim.transform;
        }else{
            target = player.transform;
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
        //Only hit solid stuff and player
        if(!other.gameObject.CompareTag("Solid") && !other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("Enemy")) return;

        if(type == ProjectileType.Player && !other.gameObject.CompareTag("Player") 
        || type == ProjectileType.Enemy && !other.gameObject.CompareTag("Enemy")){
            Debug.Log(other);
            GameObject newExplosion = Instantiate(explosion, transform.position, Quaternion.identity);
            newExplosion.GetComponent<Explosion>().type = type;
            newExplosion.GetComponent<Explosion>().diceValue = diceValue;
            Destroy(gameObject);
        }
        
    }
}

public enum ProjectileType {
    Player,
    Enemy
}
