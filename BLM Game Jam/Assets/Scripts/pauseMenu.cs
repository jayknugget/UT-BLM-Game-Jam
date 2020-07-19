using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public GameObject pauseScreen;
    private bool gameIsPaused = false;   

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
    }

    public void unpauseGame(){
        Time.timeScale = 1f;
        gameIsPaused = false;
        pauseScreen.SetActive(false);
    }

    public void quitGame(){
        Debug.Log("quit game");
        Application.Quit();
    }

    public void restart(){
        Time.timeScale = 1f;
        gameIsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
