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

    public float magicFactor = 5f;

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.FindWithTag("Player");
        player2 = GameObject.FindWithTag("Player2");
        thisCamera = GetComponent<Camera>();

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

        thisCamera.orthographicSize = Mathf.Clamp(Mathf.Abs(pos2.x - pos1.x) / magicFactor, minCameraSize, maxCameraSize);
        // todo, lerp camera
        thisCamera.transform.position = CenterCamera(pos1, pos2);
    }

    private Vector3 CenterCamera(Vector2 pos1, Vector2 pos2)
    {
        Vector3 newCam = new Vector3();
        newCam.x = (pos1.x + pos2.x) / 2;
        newCam.y = (pos1.y + pos2.y) / 2;
        newCam.z = -10;

        return newCam;
    }

    private Vector2 GetPlayerPosition(GameObject player1)
    {
        return player1.transform.position;
    }
}
