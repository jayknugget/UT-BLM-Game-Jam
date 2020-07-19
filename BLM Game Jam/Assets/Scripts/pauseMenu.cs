using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public GameObject pauseScreen;
    private bool gameIsPaused = false; 
    private GameObject backgroundMusic;  

    void Awake()
    {
        backgroundMusic = GameObject.FindGameObjectWithTag("BackgroundMusic");
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Escape)){
           if(gameIsPaused){
               unpauseGame();
           }else{
               pauseGame();
           }
       } 
    }

    public void pauseGame(){
        Time.timeScale = 0f;
        gameIsPaused = true;
        pauseScreen.SetActive(true);
        backgroundMusic.GetComponent<AudioSource>().volume = .5f;

    }

    public void unpauseGame(){
        Time.timeScale = 1f;
        gameIsPaused = false;
        pauseScreen.SetActive(false);
        backgroundMusic.GetComponent<AudioSource>().volume = 1f;
    }

    public void quitGame(){
        Debug.Log("quit game");
        Application.Quit();
    }

    public void restart(){
        Time.timeScale = 1f;
        gameIsPaused = false;
        backgroundMusic.GetComponent<AudioSource>().volume = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
