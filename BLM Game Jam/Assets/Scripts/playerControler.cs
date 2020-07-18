using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Place this on just one player and then drag in all the references

public class playerControler : MonoBehaviour
{
    private GameObject redPlayer;
    private Rigidbody2D redRB;
    private Animator redAnim;
    private GameObject greenPlayer;
    private Rigidbody2D greenRB;
    private Animator greenAnim;
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
        greenAnim = greenPlayer.GetComponent<Animator>();
        redAnim = redPlayer.GetComponent<Animator>();
        hasDoubleJump = true; 
        groundLayers = LayerMask.GetMask("Ground");
    }

    void Update(){

        if(greenIsGrounded){
            hasDoubleJump = true;
        }else{
            greenAnim.Play("green_jump_anim");
        }
        
        if(!redIsGrounded){
            redAnim.Play("red_jump_anim");
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
        //greenIsGrounded = Physics2D.OverlapCircle(greenGroundCheck.transform.position, .3f, groundLayers);
        //redIsGrounded = Physics2D.OverlapCircle(redGroundCheck.transform.position, .3f, groundLayers);
        
        greenIsGrounded = Physics2D.OverlapBox(greenGroundCheck.transform.position,new Vector2(0.87f,.3f),0f,groundLayers);
        redIsGrounded = Physics2D.OverlapBox(redGroundCheck.transform.position, new Vector2(.88f,.3f),0f,groundLayers);

        //show width of ground check boxes
        /*Debug.DrawLine(redGroundCheck.transform.position-new Vector3(.44f,0f,0f),redGroundCheck.transform.position+new Vector3(.44f,0f,0f),Color.white);
        Debug.DrawLine(greenGroundCheck.transform.position-new Vector3(.435f,0f,0f),greenGroundCheck.transform.position+new Vector3(.435f,0f,0f),Color.white);
        */
        //movement of green
        if(greenIsGrounded){
            //on ground
            if(Input.GetKey("d")){
                greenRB.velocity = new Vector2(greenSpeedGround,greenRB.velocity.y);
                greenAnim.Play("green_walk_anim");
                greenPlayer.GetComponent<SpriteRenderer>().flipX = false;
            }else if(Input.GetKey("a")){
                greenRB.velocity = new Vector2(-greenSpeedGround,greenRB.velocity.y);
                greenAnim.Play("green_walk_anim");
                greenPlayer.GetComponent<SpriteRenderer>().flipX = true;
            }else if(greenIsGrounded){
                greenAnim.Play("green_idle_anim");
                greenRB.velocity = new Vector2(0f,0f);
            }
        }else{
            //in air
            if(Input.GetKey("d")){
                greenRB.velocity = new Vector2(greenSpeedAir,greenRB.velocity.y);
                greenPlayer.GetComponent<SpriteRenderer>().flipX = false;
            }else if(Input.GetKey("a")){
                greenRB.velocity = new Vector2(-greenSpeedAir,greenRB.velocity.y);
                greenPlayer.GetComponent<SpriteRenderer>().flipX = true;
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
                redAnim.Play("red_walk2_anim");
                redPlayer.GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (Input.GetKey("left")){
                redRB.velocity = new Vector2(-redSpeedGround, redRB.velocity.y);
                redAnim.Play("red_walk2_anim");
                redPlayer.GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (redIsGrounded){
                redAnim.Play("red_idle_anim");
                redRB.velocity = new Vector2(0f,0f);
                //idle
                //Debug.Log("Idle");
            }
        } else {
            if (Input.GetKey("right")){
                redRB.velocity = new Vector2(redSpeedAir, redRB.velocity.y);
                redPlayer.GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (Input.GetKey("left"))
            {
                redRB.velocity = new Vector2(-redSpeedAir, redRB.velocity.y);
                redPlayer.GetComponent<SpriteRenderer>().flipX = true;
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
