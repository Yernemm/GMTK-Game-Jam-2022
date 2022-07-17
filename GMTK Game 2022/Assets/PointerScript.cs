using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerScript : MonoBehaviour
{

    GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameObject.Find("GameController").GetComponent<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(gameState.objective);
    }
}
