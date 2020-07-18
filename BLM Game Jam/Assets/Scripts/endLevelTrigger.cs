using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Place this on different colored doors.
public class endLevelTrigger : MonoBehaviour
{

    private static bool greenHasFinished;
    private static bool redHasFinished;
    public string allowedPlayerTag;
    public volatile string nextSceneName;
    public bool isLevel;

    void Start()
    {
        if (isLevel)
        {
            string sceneName = SceneManager.GetActiveScene().name;
            int sceneNum = int.Parse(sceneName.Substring("Level".Length));
            nextSceneName = "Level" + (sceneNum + 1);
        }
    }

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

        if (redHasFinished && greenHasFinished)
        {
            SceneControl.GoToScene(nextSceneName);  // uses static call instead
        }
    }

    void Awake() {
        redHasFinished = false;
        greenHasFinished = false;
    }
}
