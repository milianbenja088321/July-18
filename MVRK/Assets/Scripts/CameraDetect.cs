﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDetect : MonoBehaviour
{

    string camName = "THETA UVC FullHD Blender";
    public int cameraIndex = 1;
    [SerializeField] Material test = null;

    WebCamDevice[] devices;
    WebCamTexture cam;

    public float deltaTime;
    // Use this for initialization


    void Start()
    {

        Application.targetFrameRate = 60;
        Application.RequestUserAuthorization(UserAuthorization.WebCam);
        WebCamDevice[] devices = WebCamTexture.devices;
        Debug.Log("Number of web cams connected: " + devices.Length);
        Renderer rend = this.GetComponentInChildren<Renderer>();

        for (int i = 0; i < devices.Length; i++)
        {
            Debug.Log(i + ": " + devices[i].name);
        }
        WebCamTexture mycam = new WebCamTexture(100000, 100000);

        string camName = devices[cameraIndex].name;
        Debug.Log("The webcam name is " + camName);

        mycam.deviceName = camName;
        rend.material.mainTexture = mycam;
        mycam.Play();
        cam = mycam;
    }

    //private void Update()
    //{

    //    //deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
    //    //float fps = 1.0f / deltaTime;
    //    //Debug.Log(Mathf.Ceil(fps).ToString());

    //    Debug.Log("Width: " + cam.width + " " + "Height: " + cam.height);

    //}
}



