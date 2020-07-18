using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{
    private Vector3 leftEndPosition;
    private Vector3 rightEndPosition;
    private bool goingRight;
    
    //stops the platform from moving the player once they get off
    /*void OnCollisionExit2D(Collision2D other)
    {
        other.transform.parent = this.transform.parent;
    }
    //makes it so that the player is moved by the platform
    void OnCollisionEnter2D(Collision2D other)
    {
        other.transform.parent = this.transform;
    }*/
    void Awake()
    {
        leftEndPosition = this.transform.GetChild(0).position;
        rightEndPosition = this.transform.GetChild(1).position;
        goingRight = true;

    }

    void FixedUpdate()
    {
        if(goingRight){   
            /*if(this.transform.position.x > rightEndPosition.x){
                goingRight = false;
            }else{
                this.transform.Translate(Vector3.right*Time.deltaTime);
            }*/

            if(this.transform.position == rightEndPosition){
                goingRight = false;
            }else{
                this.transform.position = Vector3.MoveTowards(this.transform.position,rightEndPosition,1f*Time.deltaTime);
            }
            
        }else{
            /*if(this.transform.position.x < leftEndPosition.x){
                goingRight = true;
            }else{
                this.transform.Translate(Vector3.left*Time.deltaTime);
            }*/

            if(this.transform.position == leftEndPosition){
                goingRight = true;
            }else{
                this.transform.position = Vector3.MoveTowards(this.transform.position,leftEndPosition,1f*Time.deltaTime);
            }
        }
    }
}
