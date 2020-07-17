using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passThrough : MonoBehaviour
{
    //The tag of the player to ignore
    public string playerToIgnoreTag;

    private GameObject playerToIgnore;
    private GameObject topOfPlayer;

    void Awake()
    {
        playerToIgnore = GameObject.FindGameObjectWithTag(playerToIgnoreTag);
        topOfPlayer = playerToIgnore.GetComponentsInChildren<Transform>()[2].gameObject;    // first child is itself
        Debug.Log(topOfPlayer.name);
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(),playerToIgnore.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(),topOfPlayer.GetComponent<Collider2D>());
    }
}
