using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.CommandLine;
using System.IO;
using System;
using UnityVolumeRendering;


public class ApplicationController : MonoBehaviour
{

    private void OnResetObject()
    {
        VolumeRenderedObject volobj = FindObjectOfType<VolumeRenderedObject>();
        volobj.gameObject.transform.position = new Vector3(0, 0, 0.5f);
        volobj.gameObject.transform.rotation = Quaternion.Euler(-90, 180, 0);

    }

    private void OnQuit()
    {
        Application.Quit();
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    private void OnNewPlane()
    {
        VolumeRenderedObject volobj = FindObjectOfType<VolumeRenderedObject>();
        VolumeObjectFactory.SpawnCrossSectionPlane(volobj);
        GameObject quad = GameObject.Find("Quad");
        quad.name = "CrossSection";
        //quad.transform.parent = volobj.gameObject.transform;

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
