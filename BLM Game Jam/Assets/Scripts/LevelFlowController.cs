using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFlowController : MonoBehaviour
{
    public playerControler playerController;    // for enabling and disabling player movement
    public GameObject tutorialCanvas;           // for displaying tutorial notecards
    public DynamicCamera levelCamera;           // for zooming in and out and handing over control
    public pauseMenu pauseMenu;                 // for knowing when game is pawsed

    private DimScreen dimScreen;

    // Start is called before the first frame update
    void Awake()
    {
        if (tutorialCanvas != null)
        {
            dimScreen = tutorialCanvas.GetComponentInChildren<DimScreen>();
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
        // TODO: show tutorial notecard
        yield return new WaitForSeconds(3); // debounce player input so they don't skip it

        while (!Input.anyKeyDown)           // wait for the user to press a key
        {
            yield return null;
        }
        // TODO: show text to press any button

        dimScreen.DimOut();
        while (dimScreen.isDimming)         // wait for screen to dim in
        {
            yield return null;
        }

        playerController.enabled = true;    // enable player input
        levelCamera.normalMode = true;      // zoom in to the players
    }
}
