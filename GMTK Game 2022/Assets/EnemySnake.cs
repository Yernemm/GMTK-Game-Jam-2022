using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySnake : MonoBehaviour
{

    public float speed = 2300f;
    public float turnSpeed = 5f;



    public GameObject player;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame[]
    void FixedUpdate()
    {
        Vector3 v = gameObject.GetComponent<Rigidbody>().velocity;
        gameObject.GetComponent<Rigidbody>().velocity =  new Vector3(v.x * 0.5f, v.y * 0.5f, v.z * 0.5f);
        gameObject.GetComponent<Rigidbody>().velocity += transform.TransformDirection(new Vector3(0,0, speed * Time.deltaTime));


    }
    void Update(){
        Quaternion initRotation = transform.rotation;
        Quaternion lookAtPlayer = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(initRotation, lookAtPlayer, turnSpeed * Time.deltaTime);
       
    }
/*
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag != "PowerCube" || (other.gameObject.tag == "PowerCube" && other.gameObject.GetComponent<PowerBlockInteraction>().isCharged)){
            Debug.Log(other);
            GameObject newExplosion = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(newExplosion, 25f);
            Destroy(gameObject);
        }
        
    }
    */
}
