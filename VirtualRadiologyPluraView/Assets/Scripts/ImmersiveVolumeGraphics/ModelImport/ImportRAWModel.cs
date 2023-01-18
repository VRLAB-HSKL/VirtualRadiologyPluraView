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
        var initDataPath = InitDataPath; // ModelPath + ".ini";  //Application.streamingAssetsPath + "/" + ModelPath + ".ini";
        var rawDataPath = RawDataPath; //ModelPath + ".raw"; //Application.streamingAssetsPath + "/" + ModelPath + ".raw";
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
            //RawDatasetImporter importer = new RawDatasetImporter(Application.dataPath + "/StreamingAssets/" + ModelPath + ".raw", InitalizationData.dimX, InitalizationData.dimY, InitalizationData.dimZ, InitalizationData.format, InitalizationData.endianness, InitalizationData.bytesToSkip);
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
        var initDataPath = InitDataPath; // ModelPath + ".ini";  //Application.streamingAssetsPath + "/" + ModelPath + ".ini";
        var rawDataPath = RawDataPath; //ModelPath + ".raw"; //Application.streamingAssetsPath + "/" + ModelPath + ".raw";
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
            //RawDatasetImporter importer = new RawDatasetImporter(Application.dataPath + "/StreamingAssets/" + ModelPath + ".raw", InitalizationData.dimX, InitalizationData.dimY, InitalizationData.dimZ, InitalizationData.format, InitalizationData.endianness, InitalizationData.bytesToSkip);
            RawDatasetImporter importer = new RawDatasetImporter(
                rawDataPath,
                InitalizationData.dimX, InitalizationData.dimY, InitalizationData.dimZ,
                InitalizationData.format, InitalizationData.endianness, InitalizationData.bytesToSkip);

            VolumeDataset dataset = null;

            var sw = new Stopwatch();
            var sb = new StringBuilder();

            sw.Start();
            //yield return importer.ImportRoutine(x => dataset = x);
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
                //VolumeObjectFactory.CreateObject(dataset);
                VolumeRenderedObject vol;
                //yield return StartCoroutine(VolumeObjectFactory.CreateObjectRoutine(dataset, x => vol = x));
                VolumeObjectFactory.CreateObject(dataset);

                sw.Stop();
                sb.AppendLine("VolumeObjectCreation: " + sw.ElapsedMilliseconds + " ms");
                sw.Restart();

                yield return null;


                VolumeRenderedObject volobj = FindObjectOfType<VolumeRenderedObject>();
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
                    // volobj.gameObject.transform.localScale = new Vector3((initData.dimX *DICOMMetaReader.getThickness())/ 1000, (initData.dimY * DICOMMetaReader.getThickness()) / 1000, (initData.dimZ * DICOMMetaReader.getThickness()) / 1000);

                    // DICOMMetaReader.getThickness()
                    // volobj.gameObject.transform.localScale = new Vector3((initData.dimX * 0.46875f) / 1000, (initData.dimY * 0.46875f) / 1000, (initData.dimZ * 0.46875f) / 1000);

                    volobj.gameObject.transform.localScale = new Vector3((InitalizationData.dimX * DICOMMetaReader.GetPixelSpacingX() * 1.0f) / 1000, (InitalizationData.dimY * 1.0f * DICOMMetaReader.GetPixelSpacingX()) / 1000, (InitalizationData.dimZ * 1.0f * DICOMMetaReader.GetThickness()) / 1000);

                    sw.Stop();
                    sb.AppendLine("VolumeObjectThicknessScaling: " + sw.ElapsedMilliseconds + " ms");
                    sw.Restart();

                    //yield return null;
                }

                volobj.gameObject.AddComponent(typeof(moveCube));
                //volobj.gameObject.AddComponent(typeof(PlayerControls));
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
