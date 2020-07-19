using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCamera : MonoBehaviour
{
    public float minCameraSize = 5f;
    public float maxCameraSize = 15f;

    private GameObject player1;
    private GameObject player2;
    private Camera thisCamera;
    private GameObject bgGameObject;
    private Vector2 minBgBounds;
    private Vector2 maxBgBounds;
    private float screenAspect;

    public float screenScalingPercentBoundary = 0.8f; // screen scales when the players are this % of the way out the screen
    public bool normalMode = false;

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.FindWithTag("greenPlayer");
        player2 = GameObject.FindWithTag("redPlayer");
        thisCamera = GetComponent<Camera>();
        screenAspect = (float)Screen.width / (float)Screen.height;
        screenScalingPercentBoundary = Mathf.Clamp(screenScalingPercentBoundary, 0, 1.0f);

        bgGameObject = GameObject.FindWithTag("Background");
        if (bgGameObject != null)
        {
            Vector3 unscaledExtents = bgGameObject.GetComponent<SpriteRenderer>().sprite.bounds.extents;
            float scaleFactor = bgGameObject.transform.lossyScale.x;
            Vector3 scaledExtents = Vector3.Scale(unscaledExtents, new Vector3(scaleFactor, scaleFactor, 0))
                - new Vector3(1f, 1f / screenAspect);
            Vector3 center = bgGameObject.transform.position;
            minBgBounds = center - scaledExtents - new Vector3(0, 1f / screenAspect);
            maxBgBounds = center + scaledExtents + new Vector3(0, 1f / screenAspect);

            maxCameraSize = Mathf.Min(maxCameraSize, scaledExtents.y);
            thisCamera.orthographicSize = maxCameraSize;
        }
        else
        {
            Debug.LogWarning("There is no background SpriteRenderer in the scene.");
        }

        PreCenterCamera();
        TransformCamera();
    }

    private void PreCenterCamera()
    {
        Vector2 pos1 = GetPlayerPosition(player1);
        Vector2 pos2 = GetPlayerPosition(player2);

        thisCamera.transform.position = CenterCamera(pos1, pos2);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TransformCamera();
    }

    private void TransformCamera()
    {
        Vector2 pos1 = GetPlayerPosition(player1);
        Vector2 pos2 = GetPlayerPosition(player2);

        float newCamSize = Mathf.Clamp(GetNewScale(pos1, pos2), minCameraSize, maxCameraSize);
        thisCamera.orthographicSize = Mathf.Lerp(thisCamera.orthographicSize, newCamSize, 0.1f);

        thisCamera.transform.position = Vector3.Lerp(thisCamera.transform.position, CenterCamera(pos1, pos2), 0.1f);
    }

    private float GetNewScale(Vector2 pos1, Vector2 pos2)
    {
        if (!normalMode)
        {
            return thisCamera.orthographicSize;
        }
        Vector3 camCenter = (pos1 + pos2) / 2;
        Vector3 camDims = GetCamExtents() * 2;
        Vector3 playerDiff = pos2 - pos1;
        Vector3 playerScreenProportion = new Vector3(Math.Abs(playerDiff.x) / camDims.x, Math.Abs(playerDiff.y) / camDims.y);

        float newHeight = 0;
        if (playerScreenProportion.x > playerScreenProportion.y)
        {
            float newWidth = playerScreenProportion.x * camDims.x / screenScalingPercentBoundary;
            newHeight = newWidth / screenAspect;
        }
        else
        {
            newHeight = playerScreenProportion.y * camDims.y / screenScalingPercentBoundary;
        }

        return newHeight / 2;
    }

    private Vector3 CenterCamera(Vector2 pos1, Vector2 pos2)
    {
        Vector3 newCam = new Vector3();
        newCam = (pos1 + pos2) / 2;

        Vector3 adjustedCamCenter = AdjustToBGEdge(newCam);
        adjustedCamCenter.z = -10;

        return adjustedCamCenter;
    }

    private Vector3 AdjustToBGEdge(Vector3 newCam)
    {
        if (bgGameObject == null)
        {
            return newCam;
        }

        Vector3 camCenter = newCam;
        Vector3 camExtents = GetCamExtents();

        return BoundCamera(camCenter, camExtents);
    }

    private Vector3 BoundCamera(Vector3 camCenter, Vector3 camExtents)
    {
        Vector3 leftDown = camCenter - camExtents;
        for (int i = 0; i < 2; i++)
        {
            leftDown[i] = Mathf.Max(leftDown[i], minBgBounds[i]);
        }
        camCenter = leftDown + camExtents;

        Vector3 rightUp = camCenter + camExtents;
        for (int i = 0; i < 2; i++)
        {
            rightUp[i] = Mathf.Min(rightUp[i], maxBgBounds[i]);
        }
        return rightUp - camExtents;
    }

    private Vector3 GetCamExtents()
    {
        float camHalfHeight = thisCamera.orthographicSize;
        return new Vector3(camHalfHeight * screenAspect, camHalfHeight);
    }

    private Vector2 GetPlayerPosition(GameObject player1)
    {
        return player1.transform.position;
    }
}
