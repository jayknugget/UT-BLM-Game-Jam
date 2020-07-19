using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endScreen : MonoBehaviour
{
    private int greenCounter;
    private int redCounter;
    void Awake()
    {
       greenCounter = SceneControl.greenCounter;   
       redCounter = SceneControl.redCounter; 

       if(greenCounter==6 && redCounter==6){
           //true ending
       } else{
           //bad ending
       }
    }

    public void Quit(){
        Debug.Log("Quit");
        Application.Quit();
    }

    public void MainMenu(){
        SceneManager.LoadScene("TitleScreen");
    }
}
