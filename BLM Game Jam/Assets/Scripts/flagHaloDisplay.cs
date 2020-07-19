using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flagHaloDisplay : MonoBehaviour
{
    private int redCount;
    private int greenCount;
    private Animator anim;
    private void Awake() {
        redCount = SceneControl.redCounter;
        greenCount = SceneControl.greenCounter;
        anim = this.GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(greenCount);
        Debug.Log(redCount);
        if(this.name == "Green Goal"){
            Debug.Log("green goal anim");
            string animationName = "greenGoal"+greenCount;
            anim.Play(animationName);
        }else if(this.name == "Red Goal"){
            string animationName = "redGoal"+redCount;
            anim.Play(animationName);
        }
        
    }


}
