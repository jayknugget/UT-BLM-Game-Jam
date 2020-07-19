using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endScreen : MonoBehaviour
{
    private int greenCounter;
    private int redCounter;
    public GameObject trueEnding;
    public GameObject badEnding;
    private GameObject hellSong;
    void Awake()
    {
        hellSong = GameObject.FindGameObjectWithTag("BackgroundMusic");
        if(hellSong!=null){
            Destroy(hellSong);
        }
       greenCounter = SceneControl.greenCounter;   
       redCounter = SceneControl.redCounter; 
       
       Debug.Log(greenCounter);
       Debug.Log(redCounter);
       if(greenCounter==6 && redCounter==6){
           trueEnding.SetActive(true);
           badEnding.SetActive(false);
       } else{
           trueEnding.SetActive(false);
           badEnding.SetActive(true);
       }
       
       SceneControl.ResetCounters();
    }

    public void Quit(){
        Debug.Log("Quit");
        Application.Quit();
    }

    public void MainMenu(){
        SceneManager.LoadScene("TitleScreen");
    }
}
