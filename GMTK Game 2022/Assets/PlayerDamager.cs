using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamager : MonoBehaviour
{

    bool dmgenabled = true;

    GameState gameState;


    // Start is called before the first frame update
    void Start()
    {
        gameState = GameObject.Find("GameController").GetComponent<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator tempDisable()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        dmgenabled = false;
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        dmgenabled = true;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player" && dmgenabled){
            gameState.damage(10);
            StartCoroutine(tempDisable());
            GameObject.Find("Player").GetComponent<PlayerController>().stateToJumping();
            GameObject.Find("Player").GetComponent<Rigidbody>().AddExplosionForce(5, transform.position, 10, 0, ForceMode.Impulse);
        }
    }
}
