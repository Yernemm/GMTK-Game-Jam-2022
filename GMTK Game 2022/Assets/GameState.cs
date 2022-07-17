using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{

    
    int playerHealth = 100;
    public GameObject spawnPoint;


    public void death(){

    }

    public void damage(int damage){
        playerHealth -= damage;
        if(playerHealth <= 0){
            death();
        }
    }

    public int getHealth(){
        return playerHealth;
    }

    public void respawn(){
        transform.position = spawnPoint.transform.position;
        playerHealth = 100;
    }

    public void heal(int amount){
        playerHealth += amount;
        if(playerHealth > 100){
            playerHealth = 100;
        }
    }





}
