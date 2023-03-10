using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityVolumeRendering;
using System.Diagnostics;
using System.Text;
using Debug = UnityEngine.Debug;

public class ImportRAWModel : MonoBehaviour
{
    public static string ModelPath
    {
        get
        {
            return Path.Combine(AssetFolderPath, ModelName);
        }
    }

    public static string ModelName = "Head";
    public static string AssetFolderPath = Application.streamingAssetsPath;

    public static string InitDataPath
    {
        get
        {
            return ModelPath + ".ini";
        }
    }

    public static string RawDataPath
    {
        get
        {
            return ModelPath + ".raw";
        }
    }

    public static string MetaTextPath
    {
        get
        {
            return ModelPath + ".txt";
        }
    }

    public static DatasetIniData InitalizationData;


    public IEnumerator OpenRAWData()
    {
        var initDataPath = InitDataPath;
        var rawDataPath = RawDataPath;
        InitalizationData = DatasetIniReader.ParseIniFile(initDataPath);
        Debug.Log("initDataPath: " + initDataPath);
        Debug.Log("rawDataPath: " + rawDataPath);
        yield return null;


        if (InitalizationData is null)
        {
            Debug.Log("INIT DATA IS NULL !");
        }

        if (InitalizationData != null)
        {
            // Import the dataset
            RawDatasetImporter importer = new RawDatasetImporter(
                rawDataPath,
                InitalizationData.dimX, InitalizationData.dimY, InitalizationData.dimZ,
                InitalizationData.format, InitalizationData.endianness, InitalizationData.bytesToSkip);
            VolumeDataset dataset = importer.Import();
            // Spawn the object
            VolumeObjectFactory.CreateObject(dataset);
        }
    }

    public void StartOpenRawData()
    {
        StartCoroutine(OpenRawDataRoutine());
    }

    public IEnumerator OpenRawDataRoutine()
    {
        var initDataPath = InitDataPath;
        var rawDataPath = RawDataPath;
        InitalizationData = DatasetIniReader.ParseIniFile(initDataPath);
        Debug.Log("initDataPath: " + initDataPath);
        Debug.Log("rawDataPath: " + rawDataPath);
        Debug.Log("txtDataPath: " + MetaTextPath);
        yield return null;


        if (InitalizationData is null)
        {
            Debug.Log("INIT DATA IS NULL !");
        }

        if (InitalizationData != null)
        {
            // Import the dataset
            RawDatasetImporter importer = new RawDatasetImporter(
                rawDataPath,
                InitalizationData.dimX, InitalizationData.dimY, InitalizationData.dimZ,
                InitalizationData.format, InitalizationData.endianness, InitalizationData.bytesToSkip);

            VolumeDataset dataset = null;

            var sw = new Stopwatch();
            var sb = new StringBuilder();

            sw.Start();
            dataset = importer.Import();
            sw.Stop();
            sb.AppendLine("Import_Time: " + sw.ElapsedMilliseconds + " ms");
            sw.Restart();

            if (dataset is null)
            {
                Debug.Log("DATASET IS NULL !");
            }

            if (dataset != null)
            {
                // Create the Volume Object
                VolumeRenderedObject vol;
                VolumeObjectFactory.CreateObject(dataset);

                sw.Stop();
                sb.AppendLine("VolumeObjectCreation: " + sw.ElapsedMilliseconds + " ms");
                sw.Restart();

                yield return null;


                VolumeRenderedObject volobj = FindObjectOfType<VolumeRenderedObject>();
                
                ApplicationController.gameObjs.Clear();
                ApplicationController.gameObjs.Add(volobj.gameObject);
                volobj.name = "VolObj";
                if (volobj is null)
                {
                    Debug.Log("volobj IS NULL");
                }

                volobj.gameObject.transform.position = new Vector3(0, 0, 0.5f);

                // Rotates the object facing us
                Vector3 rotation = new Vector3(-90, 180, 0);
                volobj.gameObject.transform.rotation = Quaternion.Euler(rotation);

                sw.Stop();
                sb.AppendLine("VolumeObjectTransformation: " + sw.ElapsedMilliseconds + " ms");
                sw.Restart();

                DICOMMetaReader.ReadDICOMMetaInformation();
                Debug.Log("slicethickness: " + DICOMMetaReader.GetThickness());

                if (DICOMMetaReader.GetThickness() > 0)
                {
                    volobj.gameObject.transform.localScale = new Vector3((InitalizationData.dimX * DICOMMetaReader.GetPixelSpacingX() * 1.0f) / 1000, (InitalizationData.dimY * 1.0f * DICOMMetaReader.GetPixelSpacingX()) / 1000, (InitalizationData.dimZ * 1.0f * DICOMMetaReader.GetThickness()) / 1000);

                    sw.Stop();
                    sb.AppendLine("VolumeObjectThicknessScaling: " + sw.ElapsedMilliseconds + " ms");
                    sw.Restart();
                }
                volobj.gameObject.AddComponent(typeof(MoveCube));
            }
        }

    }

    // We'll only allow one dataset at a time in the runtime GUI (for simplicity)




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
