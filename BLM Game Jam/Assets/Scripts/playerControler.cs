using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControler : MonoBehaviour
{
    public GameObject redPlayer;
    private Rigidbody2D redRB;
    public GameObject greenPlayer;
    private Rigidbody2D greenRB;
    public GameObject greenGroundCheck;
    private bool greenIsGrounded;
    public GameObject redGroundCheck;
    public LayerMask groundLayers;
    private bool redIsGrounded;
    public float greenSpeed = 2;
    public float redSpeed = 2;
    public float jumpForce = 5;

    // Start is called before the first frame update
    void Awake()
    {
        redRB = redPlayer.GetComponent<Rigidbody2D>();
        greenRB = greenPlayer.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //check to see if the players are touching the ground
        greenIsGrounded = Physics2D.OverlapCircle(greenGroundCheck.transform.position, .3f, groundLayers);
        redIsGrounded = Physics2D.OverlapCircle(redGroundCheck.transform.position, .3f, groundLayers);

        //movement of green
        if(Input.GetKey("d")){
            greenRB.velocity = new Vector2(greenSpeed,greenRB.velocity.y);
        }else if(Input.GetKey("a")){
            Debug.Log("left");
            greenRB.velocity = new Vector2(-greenSpeed,greenRB.velocity.y);
        }
        //green jump
        if(Input.GetKey("w")||Input.GetKey(KeyCode.Space)){
            if(greenIsGrounded){
                greenRB.velocity = new Vector2(greenRB.velocity.x, jumpForce);
            }
        }

        //movement of red
        if(Input.GetKey("right")){
            redRB.velocity = new Vector2(redSpeed, redRB.velocity.y);
        }else if(Input.GetKey("left")){
            redRB.velocity = new Vector2(-redSpeed, redRB.velocity.y);
        }
        //red jump
        if(Input.GetKey("up")||Input.GetKey(KeyCode.RightShift)){
            if(redIsGrounded){
                redRB.velocity = new Vector2(redRB.velocity.x, jumpForce);
            }
        }
    }
}
