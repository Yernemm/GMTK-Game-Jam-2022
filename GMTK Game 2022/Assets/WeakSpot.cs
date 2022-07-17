using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakSpot : MonoBehaviour
{

    public GameState gameState;

    public int diceValue = -1;

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameObject.Find("GameController").GetComponent<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void damage(int amount, int diceValue){
        if(this.diceValue == diceValue){
            gameState.damageBoss(amount);
            Debug.Log("OUTHC SDUFHVSIDUJ");
        }     
    }

    
}
