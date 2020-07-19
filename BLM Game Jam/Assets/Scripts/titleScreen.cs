using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titleScreen : MonoBehaviour
{
    public string firstLevelName;
    public GameObject title;
    public GameObject controls;

    public void startGame(){
        SceneControl.GoToScene(firstLevelName);
    }

    public void quitGame(){
        Debug.Log("Quit");
        Application.Quit();
    }

    public void controlsScreen(){
        title.SetActive(false);
        controls.SetActive(true);
    }

    public void backToTitleScreen(){
        title.SetActive(true);
        controls.SetActive(false);
    }
}
