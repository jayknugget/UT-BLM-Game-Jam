using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Place this on different colored doors.
public class endLevelTrigger : MonoBehaviour
{
    private static bool greenHasFinished;
    private static bool redHasFinished;

    public static int countDownSeconds = 3;
    public static float lerpT = 0.95f;

    public string allowedPlayerTag;
    public string nextSceneName;
    public bool isLevel;

    void Start()
    {
        SceneControl.goToSceneCalled = false;
        if (isLevel)
        {
            string sceneName = SceneManager.GetActiveScene().name;
            int sceneNum = int.Parse(sceneName.Substring("Level".Length));
            nextSceneName = "Level" + (sceneNum + 1);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == allowedPlayerTag){
            collision.gameObject.SetActive(false);
            if (collision.gameObject.tag == "redPlayer" && !redHasFinished){
                redHasFinished = true;
                GameObject greenGoal = GameObject.Find("Green Goal");
                StartEaseOutEaseInCoroutine(collision.gameObject.transform, greenGoal.transform.position);
            }
            else if(collision.gameObject.tag == "greenPlayer" && !greenHasFinished){
                greenHasFinished = true;
                GameObject redGoal = GameObject.Find("Red Goal");
                StartEaseOutEaseInCoroutine(collision.gameObject.transform, redGoal.transform.position);
                StartCoroutine(CountDown(countDownSeconds));
            }
        }

        if (redHasFinished && greenHasFinished)
        {
            SceneControl.GoToSceneTogether(nextSceneName);  // uses static call instead
        }
    }

    void StartEaseOutEaseInCoroutine(Transform player, Vector3 goal)
    {
        StartCoroutine(LerpPlayerToGoal(player, goal));
    }

    IEnumerator LerpPlayerToGoal(Transform player, Vector3 goal)
    {
        Vector3 lerpTo = player.position;
        //ease out
        Vector3 halfway = (player.position + goal) / 2;
        while (lerpTo != goal)
        {
            lerpTo = Vector3.Lerp(lerpTo, goal, 1 - lerpT);
            player.position = lerpTo;
            yield return new WaitForSeconds(1/60f);
        }

        //ease in
        while (lerpTo != goal)
        {
            lerpTo = Vector3.Lerp(lerpTo, goal, lerpT);
            player.position = lerpTo;
            yield return new WaitForSeconds(1/60f);
        }
    }

    IEnumerator CountDown(int seconds)
    {
        for (int i = seconds; i >= 0; i--) {
            // TODO: edit text for counter
            yield return new WaitForSeconds(1);
        }
        SceneControl.GoToSceneAlone(nextSceneName);
    }

    void Awake() {
        redHasFinished = false;
        greenHasFinished = false;
    }
}
