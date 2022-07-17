using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenenext : MonoBehaviour
{

    InputMaster inputMaster;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        if (inputMaster == null)
        {
            inputMaster = new InputMaster();

            inputMaster.Player.Jump.performed += ctx => {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                inputMaster.Disable();
            };

        }

        inputMaster.Enable();
    }
    
}
