using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStuff : MonoBehaviour
{

    public Sprite[] diceFaces;
    public Image diceImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateFace(int face){
        diceImage.sprite = diceFaces[face];
    }
}
