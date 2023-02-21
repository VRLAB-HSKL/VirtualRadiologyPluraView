using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using System.Text.RegularExpressions;

namespace UnityVolumeRendering
{
    /// <summary>
    /// This is a basic runtime GUI, that can be used during play mode.
    /// You can import datasets, and edit them.
    /// Add this component to an empty GameObject in your scene (it's already in the test scene) and click play to see the GUI.
    /// </summary>
    public class RuntimeGUI : MonoBehaviour
    {

        GUIStyle activeButtonStyle;
        GUIStyle normalButtonStyle;
        int selected;

        private void OnGUI()
        {
            activeButtonStyle = new GUIStyle(GUI.skin.button);
            activeButtonStyle.normal.textColor = Color.black;
            activeButtonStyle.normal.background = Texture2D.whiteTexture;

            normalButtonStyle = new GUIStyle(GUI.skin.button);
            normalButtonStyle.normal.textColor = Color.white;
            normalButtonStyle.normal.background = Texture2D.grayTexture;

            selected = ApplicationController.selectedObj;

            GUILayout.BeginVertical();


            // Show dataset import buttons
            if (GUILayout.Button("Import RAW dataset"))
            {
                RuntimeFileBrowser.ShowOpenFileDialog(OnOpenRAWDatasetResult, ImportRAWModel.AssetFolderPath);
            }

            /*if (GUILayout.Button("Import PARCHG dataset"))
            {
                RuntimeFileBrowser.ShowOpenFileDialog(OnOpenPARDatasetResult, "DataFiles");
            }*/

           /* if (GUILayout.Button("Import DICOM dataset"))
            {
                RuntimeFileBrowser.ShowOpenDirectoryDialog(OnOpenDICOMDatasetResult);
            }*/

            // Show button for opening the dataset editor (for changing the visualisation)
            if (GameObject.FindObjectOfType<VolumeRenderedObject>() != null && GUILayout.Button("Edit imported dataset"))
            {
                EditVolumeGUI.ShowWindow(GameObject.FindObjectOfType<VolumeRenderedObject>());
            }

            // Show button for opening the slicing plane editor (for changing the orientation and position)
            if (GameObject.FindObjectOfType<SlicingPlane>() != null && GUILayout.Button("Edit slicing plane"))
            {
                EditSliceGUI.ShowWindow(GameObject.FindObjectOfType<SlicingPlane>());
            }

          /*  if (GUILayout.Button("Show distance measure tool"))
            {
                DistanceMeasureTool.ShowWindow();
            }*/

            GUILayout.EndVertical();

            Rect rect = new Rect(0, Screen.height - 20, Screen.width, 20);

            GUILayout.BeginArea(rect);
            GUILayout.BeginHorizontal();
            for (int i = 0; i < ApplicationController.gameObjs.Count; i++)
            {
                if (i == 0)
                {
                    if (selected == i)
                    {
                        if (GUILayout.Button($"Scan", activeButtonStyle))
                        {
                            ApplicationController.SelectObj(i);

                        }
                    }
                    else
                    {
                        if (GUILayout.Button($"Scan", normalButtonStyle))
                        {
                            ApplicationController.SelectObj(i);

                        }
                    }
                }
                else
                {
                    if (selected == i)
                    {
                        if (GUILayout.Button($"Schnittebene {i}", activeButtonStyle))
                        {
                            ApplicationController.SelectObj(i);

                        }
                    }
                    else
                    {
                        if (GUILayout.Button($"Schnittebene {i}", normalButtonStyle))
                        {
                            ApplicationController.SelectObj(i);

                        }
                    }
                }

            }

            GUILayout.EndHorizontal();
            GUILayout.EndArea();

        }

        private void OnOpenPARDatasetResult(RuntimeFileBrowser.DialogResult result)
        {
            if (!result.cancelled)
            {
                DespawnAllDatasets();
                string filePath = result.path;
                IImageFileImporter parimporter = ImporterFactory.CreateImageFileImporter(ImageFileFormat.VASP);
                VolumeDataset dataset = parimporter.Import(filePath);
                if (dataset != null)
                {
                        VolumeObjectFactory.CreateObject(dataset);
                }
            }
        }
        
        public void OnOpenRAWDatasetResult(RuntimeFileBrowser.DialogResult result)
        {
            if(!result.cancelled)
            {

                // We'll only allow one dataset at a time in the runtime GUI (for simplicity)
                DespawnAllDatasets();

                // Did the user try to import an .ini-file? Open the corresponding .raw file instead
                string filePath = result.path;
                string fileName = Path.GetFileNameWithoutExtension(filePath);
                //Debug.Log(fileName);
                ImportRAWModel.ModelName = fileName;
                Debug.Log("Model path load - " + ImportRAWModel.ModelPath);


                var importer = FindObjectOfType<ImportRAWModel>();
                if (importer != null)
                {
                    Debug.Log("Importing initial data");
                    importer.OpenRAWData();
                    StartCoroutine(importer.OpenRawDataRoutine());
                }
            }
        }

        private void OnOpenDICOMDatasetResult(RuntimeFileBrowser.DialogResult result)
        {
            if (!result.cancelled)
            {
                // We'll only allow one dataset at a time in the runtime GUI (for simplicity)
                DespawnAllDatasets();

                bool recursive = true;

                // Read all files
                IEnumerable<string> fileCandidates = Directory.EnumerateFiles(result.path, "*.*", recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly)
                    .Where(p => p.EndsWith(".dcm", StringComparison.InvariantCultureIgnoreCase) || p.EndsWith(".dicom", StringComparison.InvariantCultureIgnoreCase) || p.EndsWith(".dicm", StringComparison.InvariantCultureIgnoreCase));

                // Import the dataset
                IImageSequenceImporter importer = ImporterFactory.CreateImageSequenceImporter(ImageSequenceFormat.DICOM);
                IEnumerable<IImageSequenceSeries> seriesList = importer.LoadSeries(fileCandidates);
                float numVolumesCreated = 0;
                foreach (IImageSequenceSeries series in seriesList)
                {
                    VolumeDataset dataset = importer.ImportSeries(series);
                    // Spawn the object
                    if (dataset != null)
                    {
                        VolumeRenderedObject obj = VolumeObjectFactory.CreateObject(dataset);
                        obj.transform.position = new Vector3(numVolumesCreated, 0, 0);
                        numVolumesCreated++;
                    }
                }
            }
        }

        private void DespawnAllDatasets()
        {
            VolumeRenderedObject[] volobjs = GameObject.FindObjectsOfType<VolumeRenderedObject>();
            foreach(VolumeRenderedObject volobj in volobjs)
            {
                GameObject.Destroy(volobj.gameObject);
            }
        }
    }
}
