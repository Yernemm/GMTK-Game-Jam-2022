using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{

    public GameObject destination;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            GameObject player = GameObject.Find("Player");
            player.GetComponent<PlayerController>().stateToWalking();
            player.gameObject.transform.position = destination.transform.position;
            
        }
    }
}
