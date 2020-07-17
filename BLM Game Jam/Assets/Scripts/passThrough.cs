using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passThrough : MonoBehaviour
{
    public GameObject playerToIgnore;

    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(),playerToIgnore.GetComponent<Collider2D>());
    }
}
