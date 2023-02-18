
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Linq;

public class LoadModelPath : MonoBehaviour
{
    public static string Path;

    // Start is called before the first frame update
    void Start()
    {
        var args = Environment.GetCommandLineArgs();

        for(var i = 0; i < args.Length; i++)
        {
            var arg = args[i];
            Debug.Log($"CLI Argument [{i}]: {arg}");

            switch (arg)
            {
                case "--asset_folder_path":
                case "-asset_folder_path":
                case "--ap":
                case "-ap":
                    if (i + 1 >= args.Length)
                    {
                        Debug.Log("No path given to -ap flag!");
                        return;
                    }

                    ImportRAWModel.AssetFolderPath = args[i + 1];
                    Debug.Log("Using asset folder: " + ImportRAWModel.AssetFolderPath);
                    break;

                case "--model":
                case "-model":
                case "--m":
                case "-m":

                    if (i + 1 >= args.Length)
                    {
                        Debug.Log("No model name given to -m flag!");
                        return;
                    }

                    ImportRAWModel.ModelName = args[i + 1];
                    Debug.Log("Using model: " + ImportRAWModel.ModelName);
                    break;
            }
        }

        if (!string.IsNullOrEmpty(ImportRAWModel.AssetFolderPath))
        {
            // If only asset folder path is set, use first file in folder as model name
            if (string.IsNullOrEmpty(ImportRAWModel.ModelName))
            {
                var firstFileName = GetFirstFilenameInPath(ImportRAWModel.AssetFolderPath);
                ImportRAWModel.ModelName = firstFileName;
            }

            var path = ImportRAWModel.ModelPath;
           /* if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(ImportRAWModel.ModelPath);
                }

            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(ImportRAWModel.ModelPath);
                }
            }*/

            //modelPath += "/" + modelName;
            Console.WriteLine("Using default model at " + ImportRAWModel.ModelPath);
        }
        else
        {
            //On no path set, default to first file in folder for now    
            ImportRAWModel.AssetFolderPath = Application.streamingAssetsPath;
            if (string.IsNullOrEmpty(ImportRAWModel.ModelName))
            {
                var firstFilename = GetFirstFilenameInPath(ImportRAWModel.AssetFolderPath);
                ImportRAWModel.ModelName = firstFilename;
                //modelPath = Application.streamingAssetsPath + "/" + ImportRAWModel.DefaultModelName;    
            }

        }

        //ImportRAWModel.SetModelPath(modelPath);
        Debug.Log("Model path load - " + ImportRAWModel.ModelPath);


        var importer = FindObjectOfType<ImportRAWModel>();
        if (importer != null)
        {
            Debug.Log("Importing initial data");
            importer.OpenRAWData();    
            StartCoroutine(importer.OpenRawDataRoutine());
        }
    }

    private string GetFirstFilenameInPath(string path)
    {
        // Attempt to get the first file in the target folder
        var di = new DirectoryInfo(path);
        var firstFileName = di.GetFiles().Select(fi => fi.Name).FirstOrDefault();
        firstFileName = firstFileName.Substring(0, firstFileName.Length - 4);
        return firstFileName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
