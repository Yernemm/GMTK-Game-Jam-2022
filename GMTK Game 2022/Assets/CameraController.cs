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
    void LateUpdate()
    {
        Debug.Log(movement);
        //transform.Rotate(movement.x, 0, 0);
        //transform.Rotate(0, 25f * Time.deltaTime, 0);

        transform.Rotate(0, movement.x * Time.deltaTime * camspeed, 0, Space.World);

        transform.rotation *= Quaternion.AngleAxis(-movement.y * Time.deltaTime * camspeed, Vector3.right);


        //clamp
        Vector3 angles = transform.localEulerAngles;

        float angle = transform.localEulerAngles.x;
        if(angle > 180 && angle < 340)
            angles.x = 340;
        else if(angle < 180 && angle > 40)
            angles.x = 40;

        transform.localEulerAngles = angles;
        
        
    }

    private void OnEnable() {
        inputMaster = new InputMaster();
        
        inputMaster.Camera.Move.performed += i => movement = i.ReadValue<Vector2>();
        inputMaster.Camera.Move.canceled += i => movement = Vector2.zero;

        inputMaster.Enable();
    }
}
