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

    //Follow target for cam used to get direction
    public GameObject followTarget;
    public GameObject dicey;

    Rigidbody rb;

    bool walkingState = true;

    Vector3 moveVelocity;

    public Collider capsuleCollider;
    public Collider diceyCollider;


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
        rb = GetComponent<Rigidbody>();
        stateToWalking();
        //capsuleCollider = GetComponent<CapsuleCollider>();
        //diceyCollider = dicey.GetComponent<Collider>();
    }

    // Update is called once per frame|
    void Update()
    {

        //Movement dir
        Vector3 moveDir = new Vector3(movement.x, 0, movement.y);

        //Vector3 moveDir = new Vector3(Mathf.Cos(followTarget.transform.rotation.eulerAngles.y),0,Mathf.Sin(followTarget.transform.rotation.eulerAngles.y));
        
        moveDir = Quaternion.AngleAxis(followTarget.transform.rotation.eulerAngles.y, Vector3.up) * moveDir;

        //moveDir *= movement.y;
        

        //Look in direction of movement
        if (moveDir != Vector3.zero && walkingState)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDir), 0.15f);
        }

        moveVelocity = moveDir * movementSpeed;

        //Move
        controller.SimpleMove(moveVelocity);


        
    }


    void Jump() {
        //jumping is rolling player
        //transform.Translate(Vector2.up * Time.deltaTime * 10);
        Debug.Log("Jump");
        toggleState();
        rb.AddForce(new Vector3(moveVelocity.x, 5f, moveVelocity.z) * 1.5f, ForceMode.Impulse);
        rb.angularVelocity = Random.insideUnitSphere * 10;
    }

    private void OnDisable() {
        
        inputMaster.Disable();
    }

    void stateToWalking(){
        walkingState = true;
        rb.isKinematic = true;
        controller.enabled = true;
        capsuleCollider.enabled = true;
        diceyCollider.enabled = false;
    }

    void stateToJumping(){
        walkingState = false;
        rb.isKinematic = false;
        controller.enabled = false;
        capsuleCollider.enabled = false;
        diceyCollider.enabled = true;
    }

    void toggleState(){
        if(walkingState) 
            stateToJumping();
        else 
            stateToWalking();
    }

    public bool getWalkingState(){
        return walkingState;
    }
}
