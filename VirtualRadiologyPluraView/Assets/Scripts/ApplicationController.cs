using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.CommandLine;
using System.IO;
using System;
using UnityVolumeRendering;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class ApplicationController : MonoBehaviour
{
    public int selectedObj = 0;

    public static List<GameObject> gameObj = new List<GameObject>();


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
        gameObj.Add(quad);
        selectedObj = gameObj.Count - 1;
        //quad.transform.parent = volobj.gameObject.transform;

    }

    private void OnDeletePlane()
    {
        if (selectedObj != 0)
        {
            var obj = gameObj[selectedObj];
            gameObj.RemoveAt(selectedObj);
            Destroy(obj);
            selectedObj--;
        }
    }

    private void OnSelectPlane(InputValue value)
    {
        int num = (int)value.Get<float>();
        if(num == selectedObj)
        {
            selectedObj = 0;
        }
        else
        {
            selectedObj = num;
        }

        Debug.Log("Nummer : " + num);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
