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

    bool hasdamaged = false;
    void Start()
    {
        gameState = GameObject.Find("GameController").GetComponent<GameState>();
        player = GameObject.Find("Player");
        GetComponent<Rigidbody>().MovePosition(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(hasdamaged) return;
        if(type == ProjectileType.Player){
            if(other.gameObject.tag == "Enemy"){
                
                Debug.Log("USDIHJFUISDHFUISDHFSUIDHFUSIDHFIUSDHF");
                other.GetComponent<WeakSpot>().damage(damage, diceValue);

                hasdamaged = true;
            }
            Debug.Log(other.name);
        }
        else if(type == ProjectileType.Enemy){
            if(other.gameObject.tag == "Player"){
                gameState.damage(damage);
                player.GetComponent<PlayerController>().stateToJumping();
                player.GetComponent<Rigidbody>().AddExplosionForce(10, transform.position, 10, 0, ForceMode.Impulse);

                hasdamaged = true;

            }
        }
    }
}
