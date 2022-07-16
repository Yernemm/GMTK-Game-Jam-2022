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

    public GameObject limbs;
    public GameObject gameController;


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

        gameController = GameObject.Find("GameController");
    }

    // Update is called once per frame|
    void Update()
    {

        Vector3 moveDir = new Vector3(movement.x, 0, movement.y);
        moveDir = Quaternion.AngleAxis(followTarget.transform.rotation.eulerAngles.y, Vector3.up) * moveDir;

        if(walkingState){
                    //Movement dir
            

            //Vector3 moveDir = new Vector3(Mathf.Cos(followTarget.transform.rotation.eulerAngles.y),0,Mathf.Sin(followTarget.transform.rotation.eulerAngles.y));
            
            

            //moveDir *= movement.y;
            

            //Look in direction of movement
            if (moveDir != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDir), 0.15f);
            }

            moveVelocity = moveDir * movementSpeed;

            //Move
            controller.SimpleMove(moveVelocity);
        }else{
            float maxHorizontalSpeed = 30f;

            float beforeSpeed = rb.velocity.magnitude;
            float airAcceleration = 10f;
            rb.AddForce(moveDir * airAcceleration, ForceMode.Acceleration);
            //rb.velocity.Normalize();
            //rb.velocity = rb.velocity * beforeSpeed;


            //clamp horizontal speed
            Vector2 horspeed = new Vector2(rb.velocity.x, rb.velocity.z);
            if (horspeed.magnitude > maxHorizontalSpeed)
            {
                horspeed.Normalize();
                horspeed *= maxHorizontalSpeed;
                rb.velocity = new Vector3(horspeed.x, rb.velocity.y, horspeed.y);
            }
        }



        
    }


    void Jump() {
        //jumping is rolling player
        //transform.Translate(Vector2.up * Time.deltaTime * 10);

        if(!walkingState) return;

        Debug.Log("Jump");
        
        stateToJumping();
        rb.AddForce(new Vector3(moveVelocity.x, 8f, moveVelocity.z) * 1.5f, ForceMode.Impulse);
        rb.maxAngularVelocity = 50f;
        rb.angularVelocity = Random.insideUnitSphere * 15;

        //gameController.GetComponent<TimeSpeed>().quickSlowMo();
        
    }

    private void OnDisable() {
        
        inputMaster.Disable();
    }

    public void stateToWalking(){
        walkingState = true;
        rb.isKinematic = true;
        controller.enabled = true;
        capsuleCollider.enabled = true;
        diceyCollider.enabled = false;
        limbs.SetActive(true);
    }

    public void stateToJumping(){
        walkingState = false;
        rb.isKinematic = false;
        controller.enabled = false;
        capsuleCollider.enabled = false;
        diceyCollider.enabled = true;
        limbs.SetActive(false);
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
