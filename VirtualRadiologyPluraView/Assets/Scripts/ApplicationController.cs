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
        if(gameObjs.Count < 9)
        {
            VolumeRenderedObject volobj = FindObjectOfType<VolumeRenderedObject>();
            VolumeObjectFactory.SpawnCrossSectionPlane(volobj);
            GameObject quad = GameObject.Find("Quad");
            quad.name = "CrossSection";
            quad.gameObject.AddComponent(typeof(MoveSlice));
            gameObjs.Add(quad);
            //quad.transform.parent = volobj.gameObject.transform;
            SelectObj(gameObjs.Count - 1);
        }
        
    }

    private void OnDeletePlane()
    {
        if (selectedObj != 0)
        {
            int oldObj = selectedObj;
            selectedObj -= 1;
            SelectObj(selectedObj);
            var obj = gameObjs[oldObj];
            gameObjs.RemoveAt(oldObj);
            Destroy(obj);
            
        }
    }

    private void OnSelectPlane(InputValue value)
    {
        int num = (int)value.Get<float>();
        if(num == selectedObj)
        {
            num = 0;
        }
        SelectObj(num);

        Debug.Log("Nummer : " + num);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SelectObj(int idx)
    {
        
        if(0 <= idx && idx < gameObjs.Count)
        {

            if (selectedObj != 0)
            {
                gameObjs[selectedObj].GetComponent<Renderer>().materials = crossSectionMat;
                gameObjs[selectedObj].GetComponent<MoveSlice>().enabled = false;

            }
            else
            {
                gameObjs[selectedObj].GetComponent<MoveCube>().enabled = false;
            }

            if (idx != 0)
            {
                gameObjs[idx].GetComponent<Renderer>().materials = selectedCrossSectionMat;
                gameObjs[idx].GetComponent<MoveSlice>().enabled = true;
            }
            else
            {
                gameObjs[idx].GetComponent<MoveCube>().enabled = true;
            }
            selectedObj = idx;
        }
        
    }
}
