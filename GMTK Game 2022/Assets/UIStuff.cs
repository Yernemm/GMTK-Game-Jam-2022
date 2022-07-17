using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStuff : MonoBehaviour
{

    public Sprite[] diceFaces;

    public Image bossBar;
    public Text bossName;

    public Image playerHealthBar;
    public Image energyBar;
    public Image diceImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateFace(int face){
        diceImage.sprite = diceFaces[face];
    }

    public void updateHealth(float healthPercent){
        playerHealthBar.fillAmount = healthPercent;
    }

    public void updateBossHealth(float healthPercent){
        bossBar.fillAmount = healthPercent;
    }

    public void updateBossName(string name){

    }

    public void updateEnergy(float energyPercent){
        energyBar.fillAmount = energyPercent;
    }
}
