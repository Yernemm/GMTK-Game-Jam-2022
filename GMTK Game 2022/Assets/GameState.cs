using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{

    
    public int playerHealth = 50;
    int maxPlayerHealth = 100;
    public GameObject spawnPoint;

    public UIStuff uiStuff;

    public int bossHealth = 150;
    public int maxBossHealth = 150;

    public Dictionary<BossType, int> bossHealths = new Dictionary<BossType, int>();

    public Dictionary<BossType, string> bossNames = new Dictionary<BossType, string>();

    public GameObject[] bossesList;

    Dictionary<BossType, GameObject> bosses = new Dictionary<BossType, GameObject>();

    BossType currentBoss;

    public GameObject bossExplosion;

    public Transform objective;

    public Queue<GameObject> objectives;

    public GameObject[] startingObjectives;

    GameObject player;
    BossType[] bossenums = {BossType.Wall, BossType.Snake, BossType.Spider, BossType.Furby};

    int currentBossIndex = -1;

    public bool isBossFighting = false;

    public AudioSource healsound;
    public AudioSource damagesound;


    private void Start() {
        bossHealths.Add(BossType.Wall, 50);
        bossHealths.Add(BossType.Snake, 100);
        bossHealths.Add(BossType.Spider, 150);
        bossHealths.Add(BossType.Furby, 200);

        bossNames.Add(BossType.Wall, "Wall of Unmoving");
        bossNames.Add(BossType.Snake, "Snake the Snakey");
        bossNames.Add(BossType.Spider, "Spider-Spider");
        bossNames.Add(BossType.Furby, "Off-brand Furthing");

        bosses.Add(BossType.Wall, bossesList[0]);
        bosses.Add(BossType.Snake, bossesList[1]);
        bosses.Add(BossType.Spider, bossesList[2]);
        bosses.Add(BossType.Furby, bossesList[3]);
        
        currentBoss = BossType.Spider;

        objectives = new Queue<GameObject>();
        foreach(GameObject obj in startingObjectives){
            objectives.Enqueue(obj);
        }

        setHealth(80);

        player = GameObject.Find("Player");

        uiStuff.updateBossName("");
        uiStuff.updateBossHealth(0);

        

    }

    private void Update() {
        objective = objectives.Peek().transform;

        if(player.transform.position.y < -10){
            death();
        }
    }

    private void FixedUpdate() {

    }

    public void death(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void damage(int damage){
        damagesound.Play();
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
        }else{
            healsound.Play();
        }
    }

    public void setHealth(int health){
        playerHealth = health;
        uiStuff.updateHealth((float)playerHealth / (float)maxPlayerHealth);
    }

    public void setBoss(BossType type){
        bossHealth = bossHealths[type];
        maxBossHealth = bossHealths[type];
        currentBoss = type;
        uiStuff.updateBossName(bossNames[type]);
        uiStuff.updateBossHealth((float)bossHealth / (float)maxBossHealth);
        isBossFighting = true;
    }

    public void damageBoss(int damage){
        bossHealth -= damage;
        uiStuff.updateBossHealth((float)bossHealth / (float)maxBossHealth);
        if(bossHealth <= 0){
            killBoss();
        }
    }

    public void killBoss(){
        Instantiate(bossExplosion, bosses[currentBoss].transform.position, Quaternion.identity);
        bosses[currentBoss].SetActive(false);
        uiStuff.updateBossName("");
        objectiveComplete();
        isBossFighting = false;
    }

    public void objectiveComplete(){
        if(objectives.Count > 0){
            Destroy(objectives.Dequeue());
            objectives.Peek().SetActive(true);
            if(objectives.Peek().tag != "Waypoint"){
                currentBossIndex++;
                setBoss(bossenums[currentBossIndex]);
            }
        }
    }

   





}

public enum BossType{
    Snake,
    Spider,
    Furby,
    Wall
}
