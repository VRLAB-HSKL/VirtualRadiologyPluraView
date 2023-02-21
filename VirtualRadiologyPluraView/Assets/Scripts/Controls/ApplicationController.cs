using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityVolumeRendering;
using UnityEngine.InputSystem;
using System.Linq;

[RequireComponent(typeof(PlayerInput))]
public class ApplicationController : MonoBehaviour
{
    public static int selectedObj = 0;

    public static List<GameObject> gameObjs = new List<GameObject>();

    static Material[] crossSectionMat = new Material[1];
    static Material[] selectedCrossSectionMat = new Material[1];

    private void Awake()
    {

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
            Debug.Log(selectedObj);
            int oldObj = selectedObj;
            SelectObj(selectedObj-1);
            var obj = gameObjs[oldObj];
            gameObjs.RemoveAt(oldObj);
            Destroy(obj);
            Debug.Log(selectedObj);
        }
    }

    private void OnSelectObject(InputValue value)
    {
        int num = (int)value.Get<float>();

        SelectObj(num);

        Debug.Log("Nummer : " + num);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnNextObject()
    {
        SelectObj((selectedObj + 1) % gameObjs.Count);
    }

    private void OnPreviousObject()
    {
        if (selectedObj > 0)
        {
            SelectObj(selectedObj - 1);
        }
        //SelectObj((selectedObj - 1) % gameObjs.Count);
    }

    public static void SelectObj(int idx)
    {
        if (idx == selectedObj)
        {
            idx = 0;
        }

        if (0 <= idx && idx < gameObjs.Count)
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
