using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFlowController : MonoBehaviour
{
    public playerControler playerController;    // for enabling and disabling player movement
    public GameObject tutorialCanvas;           // for displaying tutorial notecards
    public DynamicCamera levelCamera;           // for zooming in and out and handing over control
    public pauseMenu pauseMenu;                 // for knowing when game is pawsed

    private DimScreen dimScreen;
    private Tutorial tutorial;

    // Start is called before the first frame update
    void Awake()
    {
        dimScreen = tutorialCanvas.GetComponentInChildren<DimScreen>();
        SetTutorial();
    }

    private void SetTutorial()
    {
        Tutorial[] children = tutorialCanvas.GetComponentsInChildren<Tutorial>();
        foreach (Tutorial child in children)
        {
            child.gameObject.SetActive(false);
        }

        switch(SceneManager.GetActiveScene().name)
        {
            case "Level1":
                tutorial = children[1]; break;
            case "Level2":
                tutorial = children[0]; break;
            default:
                Debug.Log("default switch case in flow controller");
                break;
        }
    }

    void Start()
    {
        StartCoroutine(Tutorial1());
    }

    IEnumerator Tutorial1()
    {
        playerController.enabled = false;   // disable player input
        dimScreen.DimIn();
        while (dimScreen.isDimming)         // wait for screen to dim in
        {
            yield return null;
        }
        tutorial.gameObject.SetActive(true);

        yield return new WaitForSeconds(3); // debounce player input so they don't skip it

        while (!Input.anyKeyDown)           // wait for the user to press a key
        {
            yield return null;
        }
        tutorial.gameObject.SetActive(false);

        dimScreen.DimOut();
        while (dimScreen.isDimming)         // wait for screen to dim in
        {
            yield return null;
        }

        playerController.enabled = true;    // enable player input
        levelCamera.normalMode = true;      // zoom in to the players
    }
}
