using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public GameObject door;
    public float buttonDrop = 1f;
    public float buttonDebounce = 1f;

    private bool playerOnButton;
    private bool switchingStates;
    private Vector2 pos1;
    private Vector2 pos2;

    void Start()
    {
        playerOnButton = false;
        switchingStates = false;
        pos1 = gameObject.transform.position;               // up
        pos2 = new Vector2(pos1.x, pos1.y - buttonDrop);    // down
    }

    void Update()
    {
        if(!playerOnButton && !switchingStates)
        {
            door.GetComponent<BoxCollider2D>().enabled = true;
            gameObject.transform.position = pos1;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        playerOnButton = true;
        if(!switchingStates)
        {
            door.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.transform.position = pos2;
            switchingStates = true;
            StartCoroutine(SwitchDebounce());
        }
    }

    IEnumerator SwitchDebounce()
    {
        yield return new WaitForSeconds(buttonDebounce);
        switchingStates = false;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        playerOnButton = false;
        if(!switchingStates)
        {
            switchingStates = true;
            StartCoroutine(SwitchDebounce());
        }
    }
}
