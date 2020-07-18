using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatFloor : MonoBehaviour
{
    //stops the platform from moving the player once they get off
    void OnCollisionExit2D(Collision2D other)
    {
        other.transform.parent = this.transform.parent.parent;
    }
    //makes it so that the player is moved by the platform
    void OnCollisionEnter2D(Collision2D other)
    {
        other.transform.parent = this.transform.parent;
    }

}
