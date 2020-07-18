using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Place inside new EmptyObject SceneController to access functions from
 * other objects via event or pointer.
 */
public class SceneControl
{
    /**
     * Find the next scene name within the Build Settings
     */

    public static void GoToScene(string nextScene)
    {
        SceneManager.LoadScene(nextScene);
    }

    public static void GoToLoadingScene(string nextScene)
    {
        GoToScene("LoadingScene");
        AsyncOperation sceneLoading = 
            SceneManager.LoadSceneAsync(nextScene);
        // loading bar?
        // wait for input? show something in between? level description?
    }

}
