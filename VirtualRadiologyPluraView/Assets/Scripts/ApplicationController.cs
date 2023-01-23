using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.CommandLine;
using System.IO;
using System;
using UnityVolumeRendering;
using UnityEngine.InputSystem;
using System.Linq;

[RequireComponent(typeof(PlayerInput))]
public class ApplicationController : MonoBehaviour
{
    public int selectedObj = 0;

    public static List<GameObject> gameObjs = new List<GameObject>();
    Material[] selectedCrossSectionMat;
    Material[] crossSectionMat;

    private void Awake()
    {
        crossSectionMat = new Material[1];
        selectedCrossSectionMat = new Material[1];
        selectedCrossSectionMat[0] = Resources.Load<Material>("SelectedCrossSectionPlaneMat");
        crossSectionMat[0] = Resources.Load<Material>("CrossSectionPlaneMat");
    }

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
        if(selectedObj != 0)
        {
            gameObjs[selectedObj].GetComponent<Renderer>().materials = crossSectionMat;
        }
        VolumeRenderedObject volobj = FindObjectOfType<VolumeRenderedObject>();
        VolumeObjectFactory.SpawnCrossSectionPlane(volobj);
        GameObject quad = GameObject.Find("Quad");
        quad.name = "CrossSection";
        gameObjs.Add(quad);
        selectedObj = gameObjs.Count - 1;
        //quad.transform.parent = volobj.gameObject.transform;
        quad.GetComponent<Renderer>().materials = selectedCrossSectionMat;
    }

    private void OnDeletePlane()
    {
        if (selectedObj != 0)
        {
            var obj = gameObjs[selectedObj];
            gameObjs.RemoveAt(selectedObj);
            Destroy(obj);
            selectedObj--;
        }
    }

    private void OnSelectPlane(InputValue value)
    {
        if (selectedObj != 0)
        {
            gameObjs[selectedObj].GetComponent<Renderer>().materials = crossSectionMat;
        }
        int num = (int)value.Get<float>();
        if(num == selectedObj)
        {
            selectedObj = 0;
        }
        else if(gameObjs.ElementAtOrDefault(num) != null)
        {
            selectedObj = num;
            gameObjs[selectedObj].GetComponent<Renderer>().materials = selectedCrossSectionMat;
        }

        Debug.Log("Nummer : " + num);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
