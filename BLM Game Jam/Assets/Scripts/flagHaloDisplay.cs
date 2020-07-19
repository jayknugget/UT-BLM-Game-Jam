using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flagHaloDisplay : MonoBehaviour
{
    private int redCount;
    private static int rCount = 0;
    private int greenCount;
    private static int gCount = 0;
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
            if(greenCount%2==0&&greenCount!=0){
                gCount++;
            }
            string animationName = "greenGoal"+gCount;
            anim.Play(animationName);
            
            
        }else if(this.name == "Red Goal"){
            if(redCount%2==0&&redCount!=0){
                rCount++;
            }
            string animationName = "redGoal"+rCount;
            anim.Play(animationName);
        }
        
    }


}
