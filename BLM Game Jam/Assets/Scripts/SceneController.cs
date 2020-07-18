using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Place inside new EmptyObject SceneController to access functions from
 * other objects via event or pointer.
 */
public class SceneController : MonoBehaviour
{
    /**
     * Find the next scene name within the Build Settings
     */
    private string nextSceneName;
    private static bool greenHasEntered;
    private static bool redHasEntered;
    void Awake()
    {
        greenHasEntered = false;
        redHasEntered = false;
    }
    void Update()
    {
        if(greenHasEntered&&redHasEntered){
            GoToScene(nextSceneName);
        }
    }
    public void GoToScene(string nextScene)
    {
        SceneManager.LoadScene(nextScene);
    }

    public void GoToLoadingScene(string nextScene)
    {
        GoToScene("LoadingScene");
        AsyncOperation sceneLoading = 
            SceneManager.LoadSceneAsync(nextScene);
        // loading bar?
    }

    public void greenCompleted(string nextScene){
        nextSceneName = nextScene;
        greenHasEntered = true;
        
    }

    public void redCompleted(string nextScene){
        nextSceneName = nextScene;
        redHasEntered = true;
        
    }
}
