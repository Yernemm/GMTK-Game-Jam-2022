using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoller : MonoBehaviour
{

    public PlayerController playerController;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {



    }

    private void FixedUpdate() {
        if(!playerController.getWalkingState()){

        }
    }

    public int getUpSideIndex(){
        Vector3[] sides = {
            transform.up,
            -transform.up,
            transform.right,
            -transform.right,
            transform.forward,
            -transform.forward
        };

        float minAngle = float.PositiveInfinity;
        int minIndex = -1;
        for(int i = 0; i < sides.Length; i++){
            Vector3 side = sides[i];
            float angle = Vector3.Angle(side, Vector3.up);
            if(angle < minAngle){
                minAngle = angle;
                minIndex = i;
            }
        }

        return minIndex;
    }

    public int getUpSideValue(){
        int[] mapping = {5, 2, 6, 1, 3, 4};
        return mapping[getUpSideIndex()];
    }
}
