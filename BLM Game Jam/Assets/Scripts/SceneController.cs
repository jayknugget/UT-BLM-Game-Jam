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

}
