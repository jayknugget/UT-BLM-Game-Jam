using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public GameObject door;
    public float buttonDrop = 1f;
    public float buttonDebounce = 0.01f;

    private bool playerOnButton;
    private bool switchingState;
    private Vector2 pos1;
    private Vector2 pos2;

    void Start()
    {
        playerOnButton = false;
        switchingState = false;
        pos1 = gameObject.transform.position;               // up
        pos2 = new Vector2(pos1.x, pos1.y - buttonDrop);    // down
    }

    void Update()
    {
        if(!playerOnButton && !switchingState)
        {
            gameObject.transform.position = pos1;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        playerOnButton = true;
        if(!switchingState)
        {
            door.GetComponent<BoxCollider2D>().enabled = false;
            switchingState = true;
            gameObject.transform.position = pos2;
            StartCoroutine(ResetSwitchingState());
        }
    }

    IEnumerator ResetSwitchingState()
    {
        yield return new WaitForSeconds(buttonDebounce);
        switchingState = false;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        playerOnButton = false;
        if(!switchingState)
        {
            door.GetComponent<BoxCollider2D>().enabled = true;
            switchingState = true;
            gameObject.transform.position = pos1;
            StartCoroutine(ResetSwitchingState());
        }
    }
}
