using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    public InputMaster inputMaster;

    public Vector2 movement;
    public CharacterController controller;

    public float movementSpeed;


    private void OnEnable() {
        if(inputMaster == null){           
            inputMaster = new InputMaster();
        
            
            //set up controls with unity input system

            inputMaster.Player.Jump.performed += ctx => Jump();

            inputMaster.Player.Move.performed += i => movement = i.ReadValue<Vector2>();
            inputMaster.Player.Move.canceled += i => movement = Vector2.zero;
        }

        inputMaster.Enable();
        


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Movement dir
        Vector3 moveDir = new Vector3(movement.x, 0, movement.y);

        //Look in direction of movement
        if (moveDir != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDir), 0.15f);
        }

        //Move
        controller.Move(moveDir * movementSpeed * Time.deltaTime);


        
    }


    void Jump() {
        //jump player
        //transform.Translate(Vector2.up * Time.deltaTime * 10);
        Debug.Log("Jump");
    }

    private void OnDisable() {
        
        inputMaster.Disable();
    }
}
