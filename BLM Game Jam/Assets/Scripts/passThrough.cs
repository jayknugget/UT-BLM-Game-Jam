using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passThrough : MonoBehaviour
{

    //Place on objects that you want to be passable through.
    public GameObject playerToIgnore;
    public GameObject topOfPlayer;

    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(),playerToIgnore.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(),topOfPlayer.GetComponent<Collider2D>());
    }
}
