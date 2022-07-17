using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{

    
    int playerHealth = 100;
    int maxPlayerHealth = 100;
    public GameObject spawnPoint;

    public UIStuff uiStuff;


    private void FixedUpdate() {
        if(Random.Range(0, 100) < 10){
            damage(5);
        }
    }

    public void death(){

    }

    public void damage(int damage){
        setHealth(playerHealth - damage);
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
        setHealth(getHealth() + amount);
        if(playerHealth > 100){
            playerHealth = 100;
        }
    }

    public void setHealth(int health){
        playerHealth = health;
        uiStuff.updateHealth((float)playerHealth / (float)maxPlayerHealth);
    }





}
