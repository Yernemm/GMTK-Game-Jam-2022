using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update

    public ProjectileType type;
    public int diceValue = -1;

    public int damage = 2;

    GameState gameState;

    GameObject player;
    void Start()
    {
        gameState = GameObject.Find("GameController").GetComponent<GameState>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(type == ProjectileType.Player){
            if(other.gameObject.tag == "Enemy"){
                
            }
        }
        else if(type == ProjectileType.Enemy){
            if(other.gameObject.tag == "Player"){
                gameState.damage(damage);
                player.GetComponent<PlayerController>().stateToJumping();
                player.GetComponent<Rigidbody>().AddExplosionForce(10, transform.position, 10, 0, ForceMode.Impulse);

            }
        }
    }
}
