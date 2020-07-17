using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Place this on just one player and then drag in all the references

public class playerControler : MonoBehaviour
{
    private GameObject redPlayer;
    private Rigidbody2D redRB;
    private GameObject greenPlayer;
    private Rigidbody2D greenRB;
    private GameObject greenGroundCheck;
    private bool greenIsGrounded;
    private GameObject redGroundCheck;
    private LayerMask groundLayers;
    private bool redIsGrounded;
    public float greenSpeedGround = 1;
    public float greenSpeedAir = 5;
    public float redSpeedGround = 5;
    public float redSpeedAir = 5;
    public float jumpForce = 5;
    private bool hasDoubleJump;

    // Start is called before the first frame update
    void Awake()
    {
        greenPlayer = GameObject.FindGameObjectWithTag("greenPlayer");
        redPlayer = GameObject.FindGameObjectWithTag("redPlayer");
        greenGroundCheck = GameObject.FindGameObjectWithTag("greenGroundCheck");
        redGroundCheck = GameObject.FindGameObjectWithTag("redGroundCheck");
        redRB = redPlayer.GetComponent<Rigidbody2D>();
        greenRB = greenPlayer.GetComponent<Rigidbody2D>();
        hasDoubleJump = true; 
        groundLayers = LayerMask.GetMask("Ground");
    }

    void Update(){

        if(greenIsGrounded){
            hasDoubleJump = true;
        }
        //green double jump
        if((Input.GetKeyDown("w")||Input.GetKeyDown(KeyCode.Space))&&!greenIsGrounded&&hasDoubleJump){
            greenRB.velocity = new Vector2(greenRB.velocity.x, jumpForce);
            hasDoubleJump = false;
        }
    }
    void FixedUpdate()
    {
        /*if(greenIsGrounded){
            hasDoubleJump = true;
        }*/
        //check to see if the players are touching the ground
        greenIsGrounded = Physics2D.OverlapCircle(greenGroundCheck.transform.position, .3f, groundLayers);
        redIsGrounded = Physics2D.OverlapCircle(redGroundCheck.transform.position, .3f, groundLayers);

        //movement of green
        if(greenIsGrounded){
            //on ground
            if(Input.GetKey("d")){
                greenRB.velocity = new Vector2(greenSpeedGround,greenRB.velocity.y);
            }else if(Input.GetKey("a")){
                greenRB.velocity = new Vector2(-greenSpeedGround,greenRB.velocity.y);
            }else if(greenIsGrounded){
                //idle
            }
        }else{
            //in air
            if(Input.GetKey("d")){
                greenRB.velocity = new Vector2(greenSpeedAir,greenRB.velocity.y);
            }else if(Input.GetKey("a")){
                greenRB.velocity = new Vector2(-greenSpeedAir,greenRB.velocity.y);
            }
        }
        
        //green double jump
        /*if((Input.GetKeyDown("w")||Input.GetKeyDown(KeyCode.Space))&&!greenIsGrounded&&hasDoubleJump&&completedJumpOne){
            greenRB.velocity = new Vector2(greenRB.velocity.x, jumpForce);
            hasDoubleJump = false;
        }*/
        //green jump
        if(Input.GetKey("w")||Input.GetKey(KeyCode.Space)){
            if(greenIsGrounded){
                greenRB.velocity = new Vector2(greenRB.velocity.x, jumpForce);
            }          
        }


        //movement of red
        if (redIsGrounded){
            if (Input.GetKey("right")){
                redRB.velocity = new Vector2(redSpeedGround, redRB.velocity.y);
            }
            else if (Input.GetKey("left")){
                redRB.velocity = new Vector2(-redSpeedGround, redRB.velocity.y);
            }
            else if (redIsGrounded){
                //idle
                //Debug.Log("Idle");
            }
        } else {
            if (Input.GetKey("right")){
                redRB.velocity = new Vector2(redSpeedAir, redRB.velocity.y);
            }
            else if (Input.GetKey("left"))
            {
                redRB.velocity = new Vector2(-redSpeedAir, redRB.velocity.y);
            }
        }
        //red jump
        if(Input.GetKey("up")||Input.GetKey(KeyCode.RightShift)){
            if(redIsGrounded){
                redRB.velocity = new Vector2(redRB.velocity.x, jumpForce);
            }
        }
    }
}
