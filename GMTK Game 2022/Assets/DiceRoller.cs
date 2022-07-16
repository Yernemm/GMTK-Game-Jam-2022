using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoller : MonoBehaviour
{

    public PlayerController playerController;
    public GameObject bounceParticle;

    // Start is called before the first frame update


    // Update is called once per frame

    public GameObject[] sideGlows;

    private bool firstRollFrame = true;
    private int bounceCount = 0;

    UIStuff uiStuff;

    private void Start() {
        uiStuff = GameObject.Find("OverlayUI").GetComponent<UIStuff>();
    }
    
    void Update()
    {



    }

    private void FixedUpdate() {
        if(!playerController.getWalkingState()){
            //We rollin
            if(bounceCount >= 1 && getAngularSpeed() < 2f || bounceCount >= 4){
                //Stop da roll
                playerController.stateToWalking();
                bounceCount = 0;
                StartCoroutine("glowSide");
                uiStuff.updateFace(getUpSideValue());
            }

        }
    }

    IEnumerator glowSide(){
        GameObject sideGlow = getUpSideGameObject();
        sideGlow.SetActive(true);
        yield return new WaitForSeconds(1f);
        sideGlow.SetActive(false);
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

    public GameObject getUpSideGameObject(){
        Debug.Log(sideGlows[getUpSideIndex()].name);
        return sideGlows[getUpSideIndex()];
    }

    void OnCollisionEnter(Collision collision) {
                foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white, 10f);
            Instantiate(bounceParticle, contact.point, Quaternion.identity);
            bounceCount++;
        }    
    }

    public float getAngularSpeed(){
        Vector3 vel = GetComponent<Rigidbody>().angularVelocity;
        return vel.magnitude;
    }
}
