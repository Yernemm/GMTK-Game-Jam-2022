using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFurby : MonoBehaviour
{


    public EnemyState state = EnemyState.Idle;

    public GameObject player;

    CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        characterController = GetComponent<CharacterController>();
        StartCoroutine("StateMachine");
    }

    // Update is called once per frame
    void Update()
    {
        if(state == EnemyState.Aim){
            //Vector3 rot = Quaternion.LookRotation(player.transform.position - transform.position).eulerAngles;
            Vector3 rot = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.transform.position - transform.position), Time.deltaTime * 5f).eulerAngles;
            rot.x = rot.z = 0;
            transform.rotation = Quaternion.Euler(rot);
        }else if(state == EnemyState.Attack){
            characterController.Move(transform.forward * Time.deltaTime * 130f);
        }
        
        Debug.Log(state);
    }

    IEnumerator StateMachine(){
        while(true){
            // Aim
            state = EnemyState.Aim;
            yield return new WaitForSeconds(.7f);
            
            // Charge
            Debug.Log("charge");
            state = EnemyState.Charge;
            yield return new WaitForSeconds(.4f);
            // Attack
            Debug.Log("ATTACK");
            state = EnemyState.Attack;
            yield return new WaitForSeconds(.35f);

            state = EnemyState.Idle;
            yield return new WaitForSeconds(1.5f);
        }
        
    }

    
}

public enum EnemyState{
    Idle,
    Aim,
    Charge,
    Attack
}
