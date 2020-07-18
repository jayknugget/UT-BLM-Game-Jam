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

    public float magicFactor = 5f;

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.FindWithTag("greenPlayer");
        player2 = GameObject.FindWithTag("redPlayer");
        thisCamera = GetComponent<Camera>();
        screenAspect = (float)Screen.width / (float)Screen.height;

        bgGameObject = GameObject.FindWithTag("Background");
        if (bgGameObject != null)
        {
            Vector3 unscaledExtents = bgGameObject.GetComponent<SpriteRenderer>().sprite.bounds.extents;
            float scaleFactor = bgGameObject.transform.lossyScale.x;
            Vector3 scaledExtents = Vector3.Scale(unscaledExtents, new Vector3(scaleFactor, scaleFactor, 0));
            Vector3 center = bgGameObject.transform.position;
            minBgBounds = center - scaledExtents;
            maxBgBounds = center + scaledExtents;

            maxCameraSize = Mathf.Min(maxCameraSize, scaledExtents.y);
        }
        else
        {
            Debug.LogWarning("There is no background SpriteRenderer in the scene.");
        }

        TransformCamera();
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

        thisCamera.orthographicSize = Mathf.Clamp(Vector3.Magnitude(pos1 - pos2) / magicFactor, minCameraSize, maxCameraSize);
        // todo, lerp camera
        thisCamera.transform.position = CenterCamera(pos1, pos2);
    }

    private Vector3 CenterCamera(Vector2 pos1, Vector2 pos2)
    {
        Vector3 newCam = new Vector3();
        newCam = (pos1 + pos2) / 2;
        newCam.z = -10;

        return AdjustToBGEdge(newCam);
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
