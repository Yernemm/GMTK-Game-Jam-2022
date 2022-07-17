using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterObjective : MonoBehaviour
{

    public GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameObject.Find("GameController").GetComponent<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            gameState.objectiveComplete();
        }
    }
}
