using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public InputMaster inputMaster;
    
    Vector2 movement;

    public float camspeed;

    public GameObject camAim;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Debug.Log(movement);
        //transform.Rotate(movement.x, 0, 0);
        //transform.Rotate(0, 25f * Time.deltaTime, 0);

        transform.Rotate(0, movement.x * Time.deltaTime * camspeed, 0, Space.World);

        transform.rotation *= Quaternion.AngleAxis(-movement.y * Time.deltaTime * camspeed, Vector3.right);


        //clamp
        Vector3 angles = transform.localEulerAngles;

/*
        float angle = transform.localEulerAngles.x;
        if(angle > 180 && angle < 340)
            angles.x = 340;
        else if(angle < 180 && angle > 40)
            angles.x = 40;
*/


        float xangletemp = angles.x;
        if (xangletemp > 360) xangletemp -= 360;
        xangletemp = Mathf.Clamp(xangletemp, -50, 80);
        angles.z = 0f;


        transform.localEulerAngles = angles;


        //ray cast to move aim object
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 100f))
        {
            camAim.transform.position = hit.point;
        }
        else
        {
            camAim.transform.position = transform.position + transform.forward * 100f;
        }
        
        
        
    }

    private void OnEnable() {
        inputMaster = new InputMaster();
        
        inputMaster.Camera.Move.performed += i => movement = i.ReadValue<Vector2>();
        inputMaster.Camera.Move.canceled += i => movement = Vector2.zero;

        inputMaster.Enable();
    }
}
