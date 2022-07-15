using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public InputMaster inputMaster;
    
    Vector2 movement;

    public float camspeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(movement);
        //transform.Rotate(movement.x, 0, 0);
        //transform.Rotate(0, 25f * Time.deltaTime, 0);
        transform.Rotate(movement.y * Time.deltaTime * camspeed, movement.x * Time.deltaTime * camspeed, 0, Space.World);
        
    }

    private void OnEnable() {
        inputMaster = new InputMaster();
        
        inputMaster.Camera.Move.performed += i => movement = i.ReadValue<Vector2>();
        inputMaster.Camera.Move.canceled += i => movement = Vector2.zero;

        inputMaster.Enable();
    }
}
