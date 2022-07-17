using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{

    
    int playerHealth = 100;
    int maxPlayerHealth = 100;
    public GameObject spawnPoint;

    public UIStuff uiStuff;

    public int bossHealth = 150;
    public int maxBossHealth = 150;

    public Dictionary<BossType, int> bossHealths = new Dictionary<BossType, int>();

    public Dictionary<BossType, string> bossNames = new Dictionary<BossType, string>();


    private void Start() {
        bossHealths.Add(BossType.Wall, 50);
        bossHealths.Add(BossType.Snake, 100);
        bossHealths.Add(BossType.Spider, 150);
        bossHealths.Add(BossType.Furby, 200);

        bossNames.Add(BossType.Wall, "Wall of Unmoving");
        bossNames.Add(BossType.Snake, "Snake the Snakey");
        bossNames.Add(BossType.Spider, "Spider-Spider");
        bossNames.Add(BossType.Furby, "Off-brand Furthing");

    }

    private void FixedUpdate() {

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

    public void setBoss(BossType type){
        bossHealth = bossHealths[type];
        maxBossHealth = bossHealths[type];
    }

    public void damageBoss(int damage){
        bossHealth -= damage;
        uiStuff.updateBossHealth((float)bossHealth / (float)maxBossHealth);
        if(bossHealth <= 0){
            killBoss();
        }
    }

    public void killBoss(){

    }





}

public enum BossType{
    Snake,
    Spider,
    Furby,
    Wall
}
