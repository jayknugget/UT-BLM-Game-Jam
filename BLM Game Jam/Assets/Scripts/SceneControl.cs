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
    public static int greenCounter = 0;
    public static int redCounter = 0;
    public static bool goToSceneCalled;

    /**
     * Find the next scene name within the Build Settings
     */

    public static void GoToScene(string nextScene)
    {
        SceneManager.LoadScene(nextScene);
    }

    public static void GoToSceneAlone(string nextScene)
    {
        if (goToSceneCalled)
        {
            return;
        }
        goToSceneCalled = true;
        greenCounter++;
        GoToScene(nextScene);
    }

    public static void GoToSceneTogether(string nextScene)
    {
        if (goToSceneCalled)
        {
            return;
        }
        goToSceneCalled = true;
        greenCounter++;
        redCounter++;
        GoToScene(nextScene);
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
