using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Place this on different colored doors.
public class endLevelTrigger : MonoBehaviour
{

    private static bool greenHasFinished;
    private static bool redHasFinished;
    public string allowedPlayerTag;
    public string nextSceneName;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == allowedPlayerTag){
            if(collision.gameObject.tag == "redPlayer"){
                redHasFinished = true;
            }else if(collision.gameObject.tag == "greenPlayer"){
                greenHasFinished = true;
            }
            collision.gameObject.SetActive(false);            
        }

    }

    void Awake() {
        redHasFinished = false;
        greenHasFinished = false;
    }

    void Update()
    {
        if(redHasFinished&&greenHasFinished){
            SceneController sc = new SceneController();
            sc.GoToScene(nextSceneName);
        }
    }
}
